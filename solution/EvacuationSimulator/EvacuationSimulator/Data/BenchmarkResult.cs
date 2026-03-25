namespace EvacuationSimulator.Data;

public class BenchmarkResult
{
    public string ScenarioName { get; }
    public RoutingAlgorithm Algorithm { get; }
    public double CompletionPercentage { get; }
    public int TotalEvacuationTime { get; }
    public double AverageRiskExposure { get; }
    public double AverageWaitingTime { get; }
    public double RuntimeMilliseconds { get; }

    public BenchmarkResult(
        string scenarioName,
        RoutingAlgorithm algorithm,
        double completionPercentage,
        int totalEvacuationTime,
        double averageRiskExposure,
        double averageWaitingTime,
        double runtimeMilliseconds)
    {
        ScenarioName = scenarioName;
        Algorithm = algorithm;
        CompletionPercentage = completionPercentage;
        TotalEvacuationTime = totalEvacuationTime;
        AverageRiskExposure = averageRiskExposure;
        AverageWaitingTime = averageWaitingTime;
        RuntimeMilliseconds = runtimeMilliseconds;
    }

    public override string ToString()
    {
        return
            $"{Algorithm}: Completion={CompletionPercentage:P1}, Time={TotalEvacuationTime}, Risk={AverageRiskExposure}, Wait={AverageWaitingTime:F2}, Runtime={RuntimeMilliseconds:F2} ms";
    }
}