namespace EvacuationSimulator.UnitTests;
using EvacuationSimulator.Data;
using EvacuationSimulator.Core;
using Point = EvacuationSimulator.Data.Point;

public static class CoreTests
{
    public static class GridTests
    {
        private const string GridString = """
                                           WWWWW
                                           W***W
                                           W***W
                                           W***W
                                           WWEWW
                                           """;

        private static readonly Grid Grid = HelperMethods.CreateGridFromString(GridString);

        public static void TestGrid()
        {
            HelperMethods.DisplayGrid(Grid);
            Point changePoint = new Point(3, 3);
            CellType changeType =  CellType.Hazard;
            Grid.SetCell(changePoint, changeType);
            Console.WriteLine($"\nChanged point ({changePoint.X}, {changePoint.Y}) to {changeType}.\n");
            HelperMethods.DisplayGrid(Grid);

            Point wallCell = new Point(0, 0);
            Point emptyCell = new Point(1, 1);
            Point outOfBoundsCell = new Point(Grid.Width + 1, Grid.Height + 1);
            Console.WriteLine("\nOut of bounds check:");
            Console.WriteLine($"Is cell ({outOfBoundsCell.X}, {outOfBoundsCell.Y}) walkable? {Grid.IsWalkable(outOfBoundsCell)}");
            Console.WriteLine("\nWall cell check:");
            Console.WriteLine($"Is cell ({wallCell.X}, {wallCell.Y}) walkable? {Grid.IsWalkable(wallCell)}");
            Console.WriteLine("\nEmpty cell check:");
            Console.WriteLine($"Is cell ({emptyCell.X}, {emptyCell.Y}) walkable? {Grid.IsWalkable(emptyCell)}");

            Point pointToCheckNeighbours = new Point(2, 3);
            Console.WriteLine($"\nGet walkable neighbours of ({pointToCheckNeighbours.X}, {pointToCheckNeighbours.Y})");
            List<Point> neighbours =  Grid.GetNeighbours(pointToCheckNeighbours);
            Console.Write("Neighbours: ");
            foreach (Point neighbour in neighbours)
            {
                Console.Write($"({neighbour.X}, {neighbour.Y}); ");
            }
            Console.WriteLine("\n");

            int newWidth = 8, newHeight = 7;
            Grid.ResizeGrid(newWidth, newHeight);
            Console.WriteLine($"Grid resized to width {newWidth}, height {newHeight}\n");
            HelperMethods.DisplayGrid(Grid);
        }
    }

    public static class HazardTests
    {
        public static void TestHazard()
        {
            Point hazardPoint = new Point(2, 2);
            double severity = 10, decayRate = 1;
            Hazard hazard = new Hazard(1, hazardPoint, severity, decayRate);
            Console.WriteLine($"Created hazard at ({hazardPoint.X}, {hazardPoint.Y}) with severity {severity} and decay rate {decayRate}.");

            Point testPoint = new Point(2, 2);
            
            Console.WriteLine($"{hazard.CalculateRiskAt(testPoint)}");
            testPoint = new Point(3, 2);
            Console.WriteLine($"{hazard.CalculateRiskAt(testPoint)}");
            testPoint = new Point(4, 2);
            Console.WriteLine($"{hazard.CalculateRiskAt(testPoint)}");
            
            hazard.UpdateProperties(5, 1.5);
            Console.WriteLine($"changed hazard properties to severity {severity} and decay rate {decayRate}.");

            
            testPoint = new Point(2, 2);
            Console.WriteLine($"{hazard.CalculateRiskAt(testPoint)}");
            testPoint = new Point(3, 2);
            Console.WriteLine($"{hazard.CalculateRiskAt(testPoint)}");
            testPoint = new Point(4, 2);
            Console.WriteLine($"{hazard.CalculateRiskAt(testPoint)}");
        }
        
    }

    private static class HelperMethods
    {
        public static Grid CreateGridFromString(string gridString)
        {
            string[] splitGrid = gridString
                .Trim()
                .Replace("\r", "")
                .Split('\n', StringSplitOptions.RemoveEmptyEntries);
            
            int width = splitGrid[0].Length;
            int height = splitGrid.Length;
            
            Grid grid = new Grid(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    CellType type;
                    switch (splitGrid[y][x])
                    {
                        case 'W':
                            type = CellType.Wall;
                            break;
                        case 'E':
                            type = CellType.Exit;
                            break;
                        case 'H':
                            type = CellType.Hazard;
                            break;
                        case 'S':
                            type = CellType.Spawn;
                            break;
                        default:
                            type = CellType.Empty;
                            break;
                    }
                    grid.SetCell(x, y, type);
                }
            }

            return grid;
        }
        public static void DisplayGrid(Grid grid)
        {
            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    char type;
                    switch (grid.GetCell(x, y))
                    {
                        case CellType.Wall:
                            type = 'W';
                            break;
                        case CellType.Exit:
                            type = 'E';
                            break;
                        case CellType.Hazard:
                            type = 'H';
                            break;
                        case CellType.Spawn:
                            type = 'S';
                            break;
                        default:
                            type = '*';
                            break;
                    }
                    
                    Console.Write($"{type} ");
                        
                }
                Console.WriteLine();
            }
        }
    }
}

