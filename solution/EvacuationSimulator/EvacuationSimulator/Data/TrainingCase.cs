namespace EvacuationSimulator.Data;

public class TrainingCase
{
    public string ScenarioName { get; }
    public ScenarioFeatures Features { get; }
    public RoutingAlgorithm BestAlgorithm { get; }

    public TrainingCase(string scenarioName, ScenarioFeatures features, RoutingAlgorithm bestAlgorithm)
    {
        ScenarioName = scenarioName;
        Features = features;
        BestAlgorithm = bestAlgorithm;
    }
}