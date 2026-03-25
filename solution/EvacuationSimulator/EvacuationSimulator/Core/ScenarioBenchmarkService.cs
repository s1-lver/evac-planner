using System.Diagnostics;
using EvacuationSimulator.Data;
using Point = EvacuationSimulator.Data.Point;

namespace EvacuationSimulator.Core;

public class ScenarioBenchmarkService
{
    private readonly ExampleScenarioLoader exampleScenarioLoader;

    public ScenarioBenchmarkService()
    {
        exampleScenarioLoader = new ExampleScenarioLoader();
    }

    public List<BenchmarkResult> BenchmarkScenario(string scenarioFilePath, double riskWeight)
    {
        List<BenchmarkResult> results = new();
        string scenarioName = Path.GetFileNameWithoutExtension(scenarioFilePath);

        foreach (RoutingAlgorithm algorithm in Enum.GetValues<RoutingAlgorithm>())
        {
            (Grid grid, List<Hazard> hazards) = BuildScenarioState(scenarioFilePath);

            Simulation simulation = new Simulation(grid, hazards, algorithm, riskWeight);

            Stopwatch stopwatch = Stopwatch.StartNew();
            simulation.InitialiseScenario();
            simulation.RunSimulation();
            stopwatch.Stop();

            SimulationMetrics metrics = simulation.Metrics;
            
            results.Add(new BenchmarkResult(
                scenarioName,
                algorithm,
                metrics.CompletionPercentage,
                metrics.TotalEvacuationTime,
                metrics.AverageRiskExposure,
                metrics.AverageWaitingTime,
                stopwatch.Elapsed.TotalMilliseconds));
        }

        return results;
    }

    public TrainingCase CreateTrainingCase(string scenarioFilePath, double riskWeight)
    {
        string scenarioName = Path.GetFileNameWithoutExtension(scenarioFilePath);

        (Grid featureGrid, List<Hazard> featureHazards) = BuildScenarioState(scenarioFilePath);
        ScenarioFeatures features = ScenarioFeatureExtractor.Extract(featureGrid, featureHazards);

        List<BenchmarkResult> results = BenchmarkScenario(scenarioFilePath, riskWeight);
        RoutingAlgorithm bestAlgorithm = BenchmarkLabelHelper.SelectBestAlgorithm(results);
        
        return new TrainingCase(scenarioName, features, bestAlgorithm);
    }

    public List<TrainingCase> CreateTrainingCases(IEnumerable<string> scenarioFilePaths, double riskWeight)
    {
        List<TrainingCase> trainingCases = new();

        foreach (string path in scenarioFilePaths.OrderBy(p => p))
        {
            trainingCases.Add(CreateTrainingCase(path, riskWeight));
        }
        
        return trainingCases;
    }

    private (Grid Grid, List<Hazard> Hazards) BuildScenarioState(string scenarioFilePath)
    {
        ExampleScenario parsed = exampleScenarioLoader.LoadFromFile(scenarioFilePath);

        Grid grid = new Grid(parsed.Width, parsed.Height);
        List<Hazard> hazards = new();
        int nextHazardId = 1;
        
        foreach (Point wall in parsed.Walls)
            grid.SetCell(wall, CellType.Wall);

        foreach (Point spawn in parsed.Spawns)
            grid.SetCell(spawn, CellType.Spawn);
        
        foreach (Point exitPoint in parsed.Exits)
            grid.SetCell(exitPoint, CellType.Exit);

        foreach (ExampleHazard hazard in parsed.Hazards)
        {
            grid.SetCell(hazard.Position, CellType.Hazard);
            hazards.Add(new Hazard(nextHazardId, hazard.Position, hazard.Severity, hazard.DecayRate));
            nextHazardId++;
        }

        return (grid, hazards);
    }
}