using EvacuationSimulator.Data;
using Point = EvacuationSimulator.Data.Point;

namespace EvacuationSimulator.Core;

public static class ScenarioFeatureExtractor
{
    public static ScenarioFeatures Extract(Grid grid, List<Hazard> hazards)
    {
        List<Point> spawns = GetCells(grid, CellType.Spawn);
        List<Point> exits = GetCells(grid, CellType.Exit);
        int obstacleCount = CountCells(grid, CellType.Wall);

        int totalCells = grid.Width * grid.Height;
        double obstacleDensity = totalCells == 0 ? 0 : (double)obstacleCount / totalCells;

        double averageHazardSeverity = hazards.Count == 0
            ? 0
            : hazards.Average(h => h.Severity);

        double minSpawnToHazardDistance = hazards.Count == 0 || spawns.Count == 0
            ? 0
            : GetMinimumDistance(spawns, hazards.Select(h => h.Position).ToList());

        double minExitToHazardDistance = hazards.Count == 0 || exits.Count == 0
            ? 0
            : GetMinimumDistance(exits, hazards.Select(h => h.Position).ToList());

        return new ScenarioFeatures(
            grid.Width,
            grid.Height,
            spawns.Count,
            exits.Count,
            hazards.Count,
            averageHazardSeverity,
            obstacleDensity,
            minSpawnToHazardDistance,
            minExitToHazardDistance);
    }

    private static int CountCells(Grid grid, CellType cellType)
    {
        int count = 0;

        for (int y = 0; y < grid.Height; y++)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                if (grid.GetCell(x, y) == cellType)
                    count++;
            }
        }

        return count;
    }

    private static List<Point> GetCells(Grid grid, CellType cellType)
    {
        List<Point> cells = new();

        for (int y = 0; y < grid.Height; y++)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                if (grid.GetCell(x, y) == cellType)
                    cells.Add(new Point(x, y));
            }
        }

        return cells;
    }

    private static double GetMinimumDistance(List<Point> a, List<Point> b)
    {
        double minDistance = double.MaxValue;

        foreach (Point first in a)
        {
            foreach (Point second in b)
            {
                double distance = ManhattanDistance(first, second);

                if (distance < minDistance)
                    minDistance = distance;
            }
        }

        return minDistance == double.MaxValue ? 0 : minDistance;
    }

    private static double ManhattanDistance(Point a, Point b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }
}