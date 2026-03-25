using System.Numerics;
using EvacuationSimulator.Data;

namespace EvacuationSimulator.Core;

public class RecommendationEngine
{
    public List<TrainingCase> TrainingData { get; }
    public int KValue { get; }

    public RecommendationEngine(List<TrainingCase> trainingData, int kValue)
    {
        if (trainingData is null || trainingData.Count == 0)
            throw new ArgumentException("Training data cannot be empty.", nameof(trainingData));

        if (kValue <= 0)
            throw new ArgumentOutOfRangeException(nameof(kValue), "K must be greater than zero.");

        TrainingData = trainingData;
        KValue = Math.Min(kValue, trainingData.Count);
    }

    public RoutingAlgorithm RecommendAlgorithm(Grid grid, List<Hazard> hazards)
    {
        ScenarioFeatures target = ScenarioFeatureExtractor.Extract(grid, hazards);
        return RecommendAlgorithm(target);
    }

    public RoutingAlgorithm RecommendAlgorithm(ScenarioFeatures target)
    {
        List<NeighbourDistance> distances = BuildNormalisedDistances(target);

        List<NeighbourDistance> nearest = distances
            .OrderBy(d => d.Distance)
            .Take(KValue)
            .ToList();

        Dictionary<RoutingAlgorithm, double> weightedVotes = new();

        foreach (NeighbourDistance neighbour in nearest)
        {
            double weight = 1.0 / (neighbour.Distance + 0.000001);

            if (!weightedVotes.ContainsKey(neighbour.TrainingCase.BestAlgorithm))
                weightedVotes[neighbour.TrainingCase.BestAlgorithm] = 0;

            weightedVotes[neighbour.TrainingCase.BestAlgorithm] += weight;
        }

        return weightedVotes
            .OrderByDescending(kvp => kvp.Value)
            .ThenBy(kvp => kvp.Key)
            .First()
            .Key;
    }

    private List<NeighbourDistance> BuildNormalisedDistances(ScenarioFeatures target)
    {
        List<ScenarioFeatures> allFeatures = TrainingData
            .Select(t => t.Features)
            .Append(target)
            .ToList();

        FeatureRanges ranges = GetFeatureRanges(allFeatures);
        double[] targetVector = ToNormalisedVector(target, ranges);
        List<NeighbourDistance> result = new();

        foreach (TrainingCase trainingCase in TrainingData)
        {
            double[] trainingVector = ToNormalisedVector(trainingCase.Features, ranges);
            double distance = CalculateDistance(targetVector, trainingVector);
            
            result.Add(new NeighbourDistance(trainingCase, distance));
        }

        return result;
    }

    private FeatureRanges GetFeatureRanges(List<ScenarioFeatures> allFeatures)
    {
        return new FeatureRanges(
            MinMax(allFeatures.Select(f => (double)f.GridWidth)),
            MinMax(allFeatures.Select(f => (double)f.GridHeight)),
            MinMax(allFeatures.Select(f => (double)f.AgentCount)),
            MinMax(allFeatures.Select(f => (double)f.ExitCount)),
            MinMax(allFeatures.Select(f => (double)f.HazardCount)),
            MinMax(allFeatures.Select(f => f.AverageHazardSeverity)),
            MinMax(allFeatures.Select(f => f.ObstacleDensity)),
            MinMax(allFeatures.Select(f => f.MinSpawnToHazardDistance)),
            MinMax(allFeatures.Select(f => f.MinExitToHazardDistance))
        );
    }

    private double[] ToNormalisedVector(ScenarioFeatures features, FeatureRanges ranges)
    {
        return new[]
        {
            Normalise(features.GridWidth, ranges.GridWidth),
            Normalise(features.GridHeight, ranges.GridHeight),
            Normalise(features.AgentCount, ranges.AgentCount),
            Normalise(features.ExitCount, ranges.ExitCount),
            Normalise(features.HazardCount, ranges.HazardCount),
            Normalise(features.AverageHazardSeverity, ranges.AverageHazardSeverity),
            Normalise(features.ObstacleDensity, ranges.ObstacleDensity),
            Normalise(features.MinSpawnToHazardDistance, ranges.MinSpawnToHazardDistance),
            Normalise(features.MinExitToHazardDistance, ranges.MinExitToHazardDistance)
        };
    }

    private double CalculateDistance(double[] a, double[] b)
    {
        double sum = 0;

        for (int i = 0; i < a.Length; i++)
        {
            double diff = a[i] - b[i];
            sum += diff * diff;
        }

        return Math.Sqrt(sum);
    }

    private (double Min, double Max) MinMax(IEnumerable<double> values)
    {
        List<double> list = values.ToList();
        return (list.Min(), list.Max());
    }

    private double Normalise(double value, (double Min, double Max) range)
    {
        if (Math.Abs(range.Max - range.Min) < 0.000001)
            return 0;
        
        return (value - range.Min) / (range.Max - range.Min);
    }

    private readonly record struct NeighbourDistance(TrainingCase TrainingCase, double Distance);

    private readonly record struct FeatureRanges(
        (double Min, double Max) GridWidth,
        (double Min, double Max) GridHeight,
        (double Min, double Max) AgentCount,
        (double Min, double Max) ExitCount,
        (double Min, double Max) HazardCount,
        (double Min, double Max) AverageHazardSeverity,
        (double Min, double Max) ObstacleDensity,
        (double Min, double Max) MinSpawnToHazardDistance,
        (double Min, double Max) MinExitToHazardDistance
    );
}