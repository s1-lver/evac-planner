using EvacuationSimulator.Data;

namespace EvacuationSimulator.Core;

public class TrainingDatasetGenerator
{
    private readonly ExampleScenarioLoader exampleScenarioLoader;
    private readonly ScenarioBenchmarkService benchmarkService;
    private readonly TrainingCaseCsvService csvService;

    public TrainingDatasetGenerator()
    {
        exampleScenarioLoader = new ExampleScenarioLoader();
        benchmarkService = new ScenarioBenchmarkService();
        csvService = new TrainingCaseCsvService();
    }

    public List<TrainingCase> GenerateFromFolder(string folderPath, string outputCsvPath, double riskWeight)
    {
        List<string> scenarioFiles = exampleScenarioLoader.GetScenarioFiles(folderPath);

        if (scenarioFiles.Count == 0)
            throw new InvalidOperationException("No scenario files were found in the training folder.");

        List<TrainingCase> trainingCases = benchmarkService.CreateTrainingCases(scenarioFiles, riskWeight);
        csvService.Save(outputCsvPath, trainingCases);

        return trainingCases;
    }

    public List<TrainingCase> LoadFromCsv(string csvPath)
    {
        return csvService.Load(csvPath);
    }
}