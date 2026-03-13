using EvacuationSimulator.Data;
using Point = EvacuationSimulator.Data.Point;

namespace EvacuationSimulator.Core;

public class Grid
{
    private CellType[,] cells;
    
    public int Width { get; private set; }
    public int Height { get; private set; }

    public Grid(int width, int height)
    {
        if (width <= 0)
            throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than zero");
        if (height <= 0)
            throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than zero");

        Width = width;
        Height = height;
        cells = new CellType[width, height];


        ClearGrid();
    }

    public bool InBounds(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }

    public bool InBounds(Point point)
    {
        return InBounds(point.X, point.Y);
    }

    public CellType GetCell(int x, int y)
    {
        if (!InBounds(x, y))
            throw new ArgumentOutOfRangeException($"({x}, {y}) is outside the grid bounds.");

        return cells[x, y];
    }

    public CellType GetCell(Point point)
    {
        return GetCell(point.X, point.Y);
    }

    public void SetCell(int x, int y, CellType cellType)
    {
        if (!InBounds(x, y))
            throw new ArgumentOutOfRangeException($"({x}, {y}) is outside the grid bounds.");
        
        cells[x, y] = cellType;
    }

    public void SetCell(Point point, CellType cellType)
    {
        SetCell(point.X, point.Y, cellType);
    }

    public bool IsWalkable(int x, int y)
    {
        if (!InBounds(x, y))
            return false;

        return cells[x, y] != CellType.Wall && cells[x, y] != CellType.Hazard;
    }

    public bool IsWalkable(Point point)
    {
        return IsWalkable(point.X, point.Y);
    }

    public List<Point> GetNeighbours(Point point)
    {
        List<Point> neighbours = new();

        for (int dy = -1; dy <= 1; dy++)
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                if (dx == 0 && dy == 0)
                    continue;

                int newX = point.X + dx;
                int newY = point.Y + dy;

                if (!IsWalkable(newX, newY))
                    continue;

                bool isDiagonal = dx != 0 && dy != 0;

                if (isDiagonal)
                {
                    int sideX = point.X + dx;
                    int sideY = point.Y;
                    int sideX2 = point.X;
                    int sideY2 = point.Y + dy;

                    if (!IsWalkable(sideX, sideY) || !IsWalkable(sideX2, sideY2))
                        continue;
                }

                neighbours.Add(new Point(newX, newY));
            }
        }
        
        return neighbours;
    }

    public void ClearGrid()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                cells[x, y] = CellType.Empty;
            }
        }
    }

    public void ResizeGrid(int newWidth, int newHeight)
    {
        if (newWidth <= 0)
            throw new ArgumentOutOfRangeException(nameof(newWidth), "Width must be greater than zero");
        if (newHeight <= 0)
            throw new ArgumentOutOfRangeException(nameof(newHeight), "Height must be greater than zero");

        CellType[,] newCells = new CellType[newWidth, newHeight];
        
        for (int y = 0; y < newHeight; y++)
        {
            for (int x = 0; x < newWidth; x++)
            {
                newCells[x, y] = CellType.Empty;
            }
        }
        
        int copyWidth = Math.Min(Width, newWidth);
        int copyHeight = Math.Min(Height, newHeight);
        
        for (int y = 0; y < copyHeight; y++)
        {
            for (int x = 0; x < copyWidth; x++)
            {
                newCells[x, y] = cells[x, y];
            }
        }

        cells = newCells;
        Width = newWidth;
        Height = newHeight;
    }
}