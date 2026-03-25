using EvacuationSimulator.Data;

namespace EvacuationSimulator.Core;

public class BenchmarkLabelHelper
{
    public static RoutingAlgorithm SelectBestAlgorithm(List<BenchmarkResult> results)
    {
        if (results is null || results.Count == 0)
            throw new ArgumentException("Benchmark results cannot be empty.", nameof(results));

        return results
            .OrderByDescending(r => r.CompletionPercentage)
            .ThenBy(r => r.AverageRiskExposure)
            .ThenBy(r => r.TotalEvacuationTime)
            .ThenBy(r => r.AverageWaitingTime)
            .ThenBy(r => r.RuntimeMilliseconds)
            .ThenBy(r => r.Algorithm)
            .First()
            .Algorithm;
    }
}