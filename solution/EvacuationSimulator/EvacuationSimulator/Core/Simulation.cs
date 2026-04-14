using System.Diagnostics;
using EvacuationSimulator.Algorithms;
using EvacuationSimulator.Data;
using Point = EvacuationSimulator.Data.Point;

namespace EvacuationSimulator.Core;

public class Simulation
{
    public Grid Grid { get; }
    public List<Agent> Agents { get; }
    public List<Hazard> Hazards { get; }
    public SimulationMetrics Metrics { get; }
    public RoutingAlgorithm SelectedAlgorithm { get; private set; }
    public int CurrentTick { get; private set; }
    public double RiskWeight { get; private set; }

    public int MaxTicks { get; set; } = 10_000;

    public Simulation(
        Grid grid,
        List<Hazard> hazards,
        RoutingAlgorithm selectedAlgorithm,
        double riskWeight)
    {
        Grid = grid ?? throw new ArgumentNullException(nameof(grid));
        Hazards = hazards ?? throw new ArgumentNullException(nameof(hazards));
        SelectedAlgorithm = selectedAlgorithm;
        RiskWeight = riskWeight;
        
        Agents = new List<Agent>();
        Metrics = new SimulationMetrics();
        CurrentTick = 0;
    }

    public void SetAlgorithm(RoutingAlgorithm selectedAlgorithm)
    {
        SelectedAlgorithm = selectedAlgorithm;
    }

    public void SetRiskWeight(double riskWeight)
    {
        if (riskWeight < 0)
            throw new ArgumentOutOfRangeException(nameof(riskWeight), "Risk weight cannot be negative.");

        RiskWeight = riskWeight;
    }

    public void InitialiseScenario()
    {
        Agents.Clear();
        Metrics.Reset();
        CurrentTick = 0;

        int nextAgentId = 1;

        for (int y = 0; y < Grid.Height; y++)
        {
            for (int x = 0; x < Grid.Width; x++)
            {
                if (Grid.GetCell(x, y) == CellType.Spawn)
                {
                    Agent agent = new Agent(nextAgentId, new Point(x, y));
                    Agents.Add(agent);
                    nextAgentId++;
                }
            }
        }

        foreach (Agent agent in Agents)
        {
            List<Point> bestPath = FindBestExitPath(agent.Position, out int nodesExplored, out TimeSpan runtime);
            agent.SetPath(bestPath);
            
            Metrics.SetPathfindingMetrics(nodesExplored, runtime);
        }
        
        Metrics.UpdateAfterTick(CurrentTick, Agents);
    }

    public void RunSimulation()
    {
        while (!CheckEndCondition())
        {
            RunTick();
        }
    }

    public bool RunTick()
    {
        if (CheckEndCondition())
            return false;

        Dictionary<Point, List<Agent>> proposedMoves = new();
        bool anyMovementOrProgress = false;

        CurrentTick++;

        foreach (Agent agent in Agents)
        {
            if (agent.HasEvacuated)
                continue;

            if (Grid.GetCell(agent.Position) == CellType.Exit)
            {
                agent.MarkEvacuated();
                anyMovementOrProgress = true;
                continue;
            }

            if (agent.PlannedPath.Count == 0)
            {
                List<Point> bestPath = FindBestExitPath(agent.Position, out int nodesExplored, out TimeSpan runtime);
                agent.SetPath(bestPath);
                Metrics.SetPathfindingMetrics(nodesExplored, runtime);
            }
            
            Point? desiredCell = agent.ChooseNextMove();

            if (desiredCell == null)
            {
                agent.Wait();
                continue;
            }

            if (!proposedMoves.ContainsKey(desiredCell.Value))
                proposedMoves[desiredCell.Value] = new List<Agent>();
            
            proposedMoves[desiredCell.Value].Add(agent);
        }

        bool movedAnyAgents = ResolveConflicts(proposedMoves);

        if (movedAnyAgents)
            anyMovementOrProgress = true;

        foreach (Agent agent in Agents)
        {
            if (agent.HasEvacuated)
                continue;

            foreach (Hazard hazard in Hazards)
            {
                agent.AddRiskExposure(hazard.CalculateRiskAt(agent.Position));
            }

            if (Grid.GetCell(agent.Position) == CellType.Exit)
            {
                agent.MarkEvacuated();
                anyMovementOrProgress = true;
            }
        }
        
        Metrics.UpdateAfterTick(CurrentTick, Agents);

        return anyMovementOrProgress;
    }

    public bool CheckEndCondition()
    {
        if (CurrentTick >= MaxTicks)
            return true;

        bool allEvacuated = Agents.Count > 0 && Agents.All(agent => agent.HasEvacuated);
        if (allEvacuated)
            return true;

        bool noActiveAgents = Agents.Count == 0;
        if (noActiveAgents)
            return true;

        bool anyAgentCanStillAct = Agents.Any(agent =>
            !agent.HasEvacuated &&
            (Grid.GetCell(agent.Position) == CellType.Exit || agent.PlannedPath.Count > 0 ||
             AnyExitReachable(agent.Position)));

        return !anyAgentCanStillAct;
    }

    private bool ResolveConflicts(Dictionary<Point, List<Agent>> proposedMoves)
    {
        HashSet<Point> occupiedCells = new();

        foreach (Agent agent in Agents)
        {
            if (!agent.HasEvacuated)
                occupiedCells.Add(agent.Position);
        }

        bool movedAnyAgents = false;

        foreach (KeyValuePair<Point, List<Agent>> entry in proposedMoves)
        {
            Point targetCell = entry.Key;
            List<Agent> contenders = entry.Value;
            
            contenders.Sort((a, b) => a.Id.CompareTo(b.Id));
            Agent chosenAgent = contenders[0]; 
            
            occupiedCells.Remove(chosenAgent.Position);

            if (!occupiedCells.Contains(targetCell))
            {
                chosenAgent.MoveTo(targetCell);
                occupiedCells.Add(targetCell);
                movedAnyAgents = true;
            }
            else
            {
                chosenAgent.Wait();
                occupiedCells.Add(chosenAgent.Position);
            }

            for (int i = 1; i < contenders.Count; i++)
            {
                contenders[i].Wait();
            }
        }
        
        return movedAnyAgents;
    }

    private List<Point> FindBestExitPath(Point start, out int totalNodesExplored, out TimeSpan totalRuntime)
    {
        List<Point> bestPath = new();
        double lowestCost = double.PositiveInfinity;

        totalNodesExplored = 0;
        Stopwatch totalStopwatch = Stopwatch.StartNew();

        foreach (Point exit in GetExitCells())
        {
            List<Point> candidatePath = Pathfinder.FindPath(
                start,
                exit,
                Grid,
                SelectedAlgorithm,
                Hazards,
                RiskWeight,
                out int nodesExplored);
            
            totalNodesExplored += nodesExplored;

            double candidateCost = Pathfinder.CalculatePathCost(candidatePath, Hazards, RiskWeight);

            if (candidatePath.Count > 0 && candidateCost < lowestCost)
            {
                lowestCost = candidateCost;
                bestPath = candidatePath;
            }
        }
        
        totalStopwatch.Stop();
        totalRuntime = totalStopwatch.Elapsed;
        
        return bestPath;
    }

    private bool AnyExitReachable(Point start)
    {
        foreach (Point exit in GetExitCells())
        {
            List<Point> path = Pathfinder.FindPath(
                start,
                exit,
                Grid,
                SelectedAlgorithm,
                Hazards,
                RiskWeight,
                out _);

            if (path.Count > 0)
                return true;
        }

        return false;
    }

    private List<Point> GetExitCells()
    {
        List<Point> exits = new();

        for (int y = 0; y < Grid.Height; y++)
        {
            for (int x = 0; x < Grid.Width; x++)
            {
                if (Grid.GetCell(x, y) == CellType.Exit)
                    exits.Add(new(x, y));
            }
        }

        return exits;
    }
}