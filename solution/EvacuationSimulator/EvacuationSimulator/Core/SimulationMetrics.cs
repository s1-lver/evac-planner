using System.Diagnostics;

namespace EvacuationSimulator.Core;

public class SimulationMetrics
{
    public int TotalEvacuationTime { get; private set; }
    public int AgentsEvacuated { get; private set; }
    public double CompletionPercentage { get; private set; }   // Store as 0.0 to 1.0
    public double AverageWaitingTime { get; private set; }
    public double AverageRiskExposure { get; private set; }
    public int NodesExplored { get; private set; }
    public TimeSpan AlgorithmRuntime { get; private set; }

    public SimulationMetrics()
    {
        Reset();
    }

    public void Reset()
    {
        TotalEvacuationTime = 0;
        AgentsEvacuated = 0;
        CompletionPercentage = 0;
        AverageWaitingTime = 0;
        AverageRiskExposure = 0;
        NodesExplored = 0;
        AlgorithmRuntime = TimeSpan.Zero;
    }

    public void UpdateAfterTick(int currentTick, List<Agent> agents)
    {
        if (agents is null)
            throw new ArgumentNullException(nameof(agents));

        TotalEvacuationTime = currentTick;

        int evacuatedCount = 0;
        int totalWaiting = 0;
        double totalRisk = 0;

        foreach (Agent agent in agents)
        {
            if (agent.HasEvacuated)
                evacuatedCount++;

            totalWaiting += agent.WaitingTime;
            totalRisk += agent.RiskExposure;
        }

        AgentsEvacuated = evacuatedCount;

        if (agents.Count > 0)
        {
            CompletionPercentage = (double)evacuatedCount / agents.Count;
            AverageWaitingTime = (double)totalWaiting / agents.Count;
            AverageRiskExposure = totalRisk / agents.Count;
        }
        else
        {
            CompletionPercentage = 0;
            AverageWaitingTime = 0;
            AverageRiskExposure = 0;
        }
    }

    public void CalculateAverages(List<Agent> agents)
    {
        if (agents is null)
            throw new ArgumentNullException(nameof(agents));

        if (agents.Count == 0)
        {
            AverageWaitingTime = 0;
            AverageRiskExposure = 0;
            CompletionPercentage = 0;
            AgentsEvacuated = 0;
            return;
        }

        int totalWaiting = 0;
        double totalRisk = 0;
        int evacuatedCount = 0;

        foreach (Agent agent in agents)
        {
            totalWaiting += agent.WaitingTime;
            totalRisk += agent.RiskExposure;

            if (agent.HasEvacuated)
                evacuatedCount++;
        }

        AgentsEvacuated = evacuatedCount;
        AverageWaitingTime = (double)totalWaiting / agents.Count;
        AverageRiskExposure = totalRisk / agents.Count;
        CompletionPercentage = (double)evacuatedCount / agents.Count;
    }

    public void SetPathfindingMetrics(int nodesExplored, TimeSpan algorithmRuntime)
    {
        if (nodesExplored < 0)
            throw new ArgumentOutOfRangeException(nameof(nodesExplored), "Nodes explored cannot be negative.");

        if (algorithmRuntime < TimeSpan.Zero)
            throw new ArgumentOutOfRangeException(nameof(algorithmRuntime), "Algorithm runtime cannot be negative.");

        NodesExplored = nodesExplored;
        AlgorithmRuntime = algorithmRuntime;
    }

    public void SetPathfindingMetrics(int nodesExplored, Stopwatch stopwatch)
    {
        if (stopwatch is null)
            throw new ArgumentNullException(nameof(stopwatch));

        SetPathfindingMetrics(nodesExplored, stopwatch.Elapsed);
    }

    public override string ToString()
    {
        return $"EvacTime={TotalEvacuationTime}, " +
               $"Evacuated={AgentsEvacuated}, " +
               $"Completion={CompletionPercentage:P1}, " +
               $"AvgWait={AverageWaitingTime:F2}, " +
               $"AvgRisk={AverageRiskExposure:F2}, " +
               $"NodesExplored={NodesExplored}, " +
               $"Runtime={AlgorithmRuntime.TotalMilliseconds:F2} ms";
    }
}