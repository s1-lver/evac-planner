using System.Diagnostics;
using EvacuationSimulator.Core;
using EvacuationSimulator.Data;
using Point = EvacuationSimulator.Data.Point;

namespace EvacuationSimulator.Algorithms;

public static class Pathfinder
{
    public static List<Point> FindPath(
        Point start,
        Point goal,
        Grid grid,
        RoutingAlgorithm algorithm,
        List<Hazard> hazards,
        double riskWeight,
        out int nodesExplored)
    {
        return algorithm switch
        {
            RoutingAlgorithm.BFS => FindPathBFS(start, goal, grid, out nodesExplored),
            RoutingAlgorithm.Dijkstra => FindPathDijkstra(start, goal, grid, hazards, riskWeight, out nodesExplored),
            RoutingAlgorithm.AStar => FindPathAStar(start, goal, grid, hazards, riskWeight, out nodesExplored),
            RoutingAlgorithm.GreedyBestFirst => FindPathGreedyBestFirst(start, goal, grid, out nodesExplored),
            _ => EmptyPath(out nodesExplored)
        };
    }

    private static List<Point> EmptyPath(out int nodesExplored)
    {
        nodesExplored = 0;
        return new List<Point>();
    }

    public static List<Point> FindPathBFS(
        Point start,
        Point goal,
        Grid grid,
        out int nodesExplored)
    {
        nodesExplored = 0;

        if (!grid.IsWalkable(start) || !grid.IsWalkable(goal))
            return new List<Point>();

        Queue<Point> frontier = new();
        HashSet<Point> visited = new();
        Dictionary<Point, Point> cameFrom = new();
        
        frontier.Enqueue(start);
        visited.Add(start);

        while (frontier.Count > 0)
        {
            Point current = frontier.Dequeue();
            nodesExplored++;

            if (current == goal)
                return ReconstructPath(cameFrom, start, goal);

            foreach (Point neighbour in grid.GetNeighbours(current))
            {
                if (visited.Contains(neighbour))
                    continue;

                visited.Add(neighbour);
                cameFrom[neighbour] = current;
                frontier.Enqueue(neighbour);
            }
        }

        return new List<Point>();
    }

    public static List<Point> FindPathDijkstra(
        Point start,
        Point goal,
        Grid grid,
        List<Hazard> hazards,
        double riskWeight,
        out int nodesExplored)
    {
        nodesExplored = 0;

        if (!grid.IsWalkable(start) || !grid.IsWalkable(goal))
            return new List<Point>();

        PriorityQueue<Point, double> frontier = new();
        Dictionary<Point, double> distance = new();
        Dictionary<Point, Point> cameFrom = new();
        HashSet<Point> visited = new();

        distance[start] = 0;
        frontier.Enqueue(start, 0);

        while (frontier.Count > 0)
        {
            Point current = frontier.Dequeue();

            if (visited.Contains(current))
                continue;

            visited.Add(current);
            nodesExplored++;

            if (current == goal)
                return ReconstructPath(cameFrom, start, goal);

            foreach (Point neighbour in grid.GetNeighbours(current))
            {
                double moveCost = GetTraversalCost(current, neighbour, hazards, riskWeight);
                double newDistance = distance[current] + moveCost;

                if (!distance.ContainsKey(neighbour) || newDistance < distance[neighbour])
                {
                    distance[neighbour] = newDistance;
                    cameFrom[neighbour] = current;
                    frontier.Enqueue(neighbour, newDistance);
                }
            }
        }

        return new List<Point>();
    }

    public static List<Point> FindPathAStar(
        Point start,
        Point goal,
        Grid grid,
        List<Hazard> hazards,
        double riskWeight,
        out int nodesExplored)
    {
        nodesExplored = 0;

        if (!grid.IsWalkable(start) || !grid.IsWalkable(goal))
            return new List<Point>();

        PriorityQueue<Point, double> frontier = new();
        Dictionary<Point, double> gScore = new();
        Dictionary<Point, Point> cameFrom = new();
        HashSet<Point> closedSet = new();

        gScore[start] = 0;
        frontier.Enqueue(start, CalculateHeuristic(start, goal));

        while (frontier.Count > 0)
        {
            Point current = frontier.Dequeue();

            if (closedSet.Contains(current))
                continue;

            closedSet.Add(current);
            nodesExplored++;

            if (current == goal)
                return ReconstructPath(cameFrom, start, goal);

            foreach (Point neighbour in grid.GetNeighbours(current))
            {
                double moveCost = GetTraversalCost(current, neighbour, hazards, riskWeight);
                double tentativeG = gScore[current] + moveCost;

                if (!gScore.ContainsKey(neighbour) || tentativeG < gScore[neighbour])
                {
                    gScore[neighbour] = tentativeG;
                    cameFrom[neighbour] = current;
                    
                    double fScore = tentativeG + CalculateHeuristic(neighbour, goal);
                    frontier.Enqueue(neighbour, fScore);
                }
            }
        }

        return new List<Point>();
    }

    public static List<Point> FindPathGreedyBestFirst(
        Point start,
        Point goal,
        Grid grid,
        out int nodesExplored)
    {
        nodesExplored = 0;

        if (!grid.IsWalkable(start) || !grid.IsWalkable(goal))
            return new List<Point>();

        PriorityQueue<Point, int> frontier = new();
        HashSet<Point> visited = new();
        Dictionary<Point, Point> cameFrom = new();

        frontier.Enqueue(start, CalculateHeuristic(start, goal));

        while (frontier.Count > 0)
        {
            Point current = frontier.Dequeue();

            if (visited.Contains(current))
                continue;

            visited.Add(current);
            nodesExplored++;
            
            if (current == goal)
                return ReconstructPath(cameFrom, start, goal);

            foreach (Point neighbour in grid.GetNeighbours(current))
            {
                if (visited.Contains(neighbour))
                    continue;
                
                if (!cameFrom.ContainsKey(neighbour))
                    cameFrom[neighbour] = current;
                
                frontier.Enqueue(neighbour, CalculateHeuristic(neighbour, goal));
            }
        }

        return new List<Point>();
    }

    public static int CalculateHeuristic(Point a, Point b)
    {
        int dx = Math.Abs(a.X - b.X);
        int dy = Math.Abs(a.Y - b.Y);

        return 10 * Math.Max(dx, dy) + 4 * Math.Min(dx, dy);
    }

    public static List<Point> ReconstructPath(
        Dictionary<Point, Point> cameFrom,
        Point start,
        Point goal)
    {
        if (start != goal && !cameFrom.ContainsKey(goal))
            return new List<Point>();
        
        List<Point> path = new();
        Point current = goal;
        
        path.Insert(0, current);

        while (current != start)
        {
            current = cameFrom[current];
            path.Insert(0, current);
        }
        
        return path;
    }

    public static int GetMoveCost(Point current, Point neighbour)
    {
        bool isDiagonal = current.X != neighbour.X && current.Y != neighbour.Y;
        return isDiagonal ? 14 : 10;
    }

    public static double GetTraversalCost(
        Point current,
        Point neighbour,
        List<Hazard> hazards,
        double riskWeight)
    {
        double baseCost = GetMoveCost(current, neighbour);
        double riskPenalty = riskWeight * GetCellRisk(neighbour, hazards);

        return baseCost + riskPenalty;
    }

    public static double GetCellRisk(Point cell, List<Hazard> hazards)
    {
        double totalRisk = 0;

        foreach (Hazard hazard in hazards)
        {
            totalRisk += hazard.CalculateRiskAt(cell);
        }

        return totalRisk;
    }

    public static double CalculatePathCost(
        List<Point> path,
        List<Hazard> hazards,
        double riskWeight)
    {
        if (path.Count == 0)
            return double.PositiveInfinity;

        if (path.Count == 1)
            return 0;

        double totalCost = 0;

        for (int i = 0; i < path.Count - 1; i++)
        {
            Point current = path[i];
            Point next = path[i + 1];
            totalCost += GetTraversalCost(current, next, hazards, riskWeight);
        }
        
        return totalCost;
    }
}