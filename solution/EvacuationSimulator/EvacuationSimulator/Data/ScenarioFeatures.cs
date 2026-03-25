namespace EvacuationSimulator.Data;

public struct ScenarioFeatures
{
    public int GridWidth { get; }
    public int GridHeight { get; }
    public int AgentCount { get; }
    public int ExitCount { get; }
    public int HazardCount { get; }
    public double AverageHazardSeverity { get; }
    public double ObstacleDensity { get; }
    public double MinSpawnToHazardDistance { get; }
    public double MinExitToHazardDistance { get; }

    public ScenarioFeatures(
        int gridWidth,
        int gridHeight,
        int agentCount,
        int exitCount,
        int hazardCount,
        double averageHazardSeverity,
        double obstacleDensity,
        double minSpawnToHazardDistance,
        double minExitToHazardDistance)
    {
        GridWidth = gridWidth;
        GridHeight = gridHeight;
        AgentCount = agentCount;
        ExitCount = exitCount;
        HazardCount = hazardCount;
        AverageHazardSeverity = averageHazardSeverity;
        ObstacleDensity = obstacleDensity;
        MinSpawnToHazardDistance = minSpawnToHazardDistance;
        MinExitToHazardDistance = minExitToHazardDistance;
    }

    public override string ToString()
    {
        return
            $"W={GridWidth}, H={GridHeight}, Agents={AgentCount}, Exits={ExitCount}, Hazards={HazardCount}, AvgHazardSeverity={AverageHazardSeverity:F2}, ObstacleDensity={ObstacleDensity:F3}, MinSpawnToHazardDistance={MinSpawnToHazardDistance:F2}, MinExitToHazardDistance={MinExitToHazardDistance}";
    }
}