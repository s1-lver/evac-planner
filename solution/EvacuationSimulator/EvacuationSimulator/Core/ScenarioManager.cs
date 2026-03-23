using EvacuationSimulator.Data;
using Point = EvacuationSimulator.Data.Point;

namespace EvacuationSimulator.Core;

public class ScenarioManager
{
    private readonly ExampleScenarioLoader exampleScenarioLoader;
    public Grid CurrentGrid { get; private set; }
    public List<Hazard> Hazards { get; }
    public EditorToolType SelectedTool { get; set; }

    private int nextHazardId;

    public ScenarioManager(int width, int height)
    {
        CurrentGrid = new Grid(width, height);
        Hazards = new List<Hazard>();
        SelectedTool = EditorToolType.WallTool;
        nextHazardId = 1;

        exampleScenarioLoader = new ExampleScenarioLoader();
    }

    public List<string> GetExampleScenarioFiles(string folderPath)
    {
        return exampleScenarioLoader.GetScenarioFiles(folderPath);
    }

    public bool LoadExampleScenarioFromFile(string filePath)
    {
        ExampleScenario scenario = exampleScenarioLoader.LoadFromFile(filePath);

        CurrentGrid = new Grid(scenario.Width, scenario.Height);
        Hazards.Clear();
        nextHazardId = 1;
        
        foreach (Point wall in scenario.Walls)
            PlaceWall(wall);
        
        foreach (Point spawn in scenario.Spawns)
            PlaceSpawn(spawn);
        
        foreach (Point exit in scenario.Exits)
            PlaceExit(exit);
        
        foreach (ExampleHazard hazard in scenario.Hazards)
            PlaceHazard(hazard.Position, hazard.Severity, hazard.DecayRate);

        return true;
    }

    public void PlaceWall(int x, int y)
    {
        ReplaceCell(x, y, CellType.Wall);
    }

    public void PlaceWall(Point position)
    {
        PlaceWall(position.X, position.Y);
    }

    public void PlaceSpawn(int x, int y)
    {
        ReplaceCell(x, y, CellType.Spawn);
    }

    public void PlaceSpawn(Point position)
    {
        PlaceSpawn(position.X, position.Y);
    }

    private void PointPlaceHazard(Point position, double severity, double decayRate)
    {
        ValidateInBounds(position);

        RemoveEntity(position.X, position.Y);
        
        CurrentGrid.SetCell(position, CellType.Hazard);
        Hazards.Add(new Hazard(nextHazardId, position, severity, decayRate));
        nextHazardId++;
    }
    public void PlaceHazard(int x, int y, double severity, double decayRate)
    {
        PointPlaceHazard(new Point(x, y), severity, decayRate);
    }

    public void PlaceHazard(Point position, double severity, double decayRate)
    {
        PointPlaceHazard(position, severity, decayRate);
    }

    public bool UpdateHazardProperties(int hazardId, double severity, double decayRate)
    {
        Hazard? targetHazard = FindHazardById(hazardId);

        if (targetHazard is null)
            return false;
        
        targetHazard.UpdateProperties(severity, decayRate);
        return true;
    }

    public void PlaceExit(Point position)
    {
        ReplaceCell(position.X, position.Y, CellType.Exit);
    }

    public void PlaceExit(int x, int y)
    {
        ReplaceCell(x, y, CellType.Exit);
    }
    
    private void PointRemoveEntity(Point position)
    {
        ValidateInBounds(position);
        RemoveHazardAt(position);
        CurrentGrid.SetCell(position, CellType.Empty);
    }

    public void RemoveEntity(Point position)
    {
        PointRemoveEntity(position);
    }

    public void RemoveEntity(int x, int y)
    {
        PointRemoveEntity(new Point(x, y));
    }

    public void ClearScenario()
    {
        CurrentGrid.ClearGrid();
        Hazards.Clear();
        nextHazardId = 1;
    }

    public void ResizeGrid(int newWidth, int newHeight)
    {
        CurrentGrid.ResizeGrid(newWidth, newHeight);
        Hazards.RemoveAll(h => !CurrentGrid.InBounds(h.Position));
    }

    public Hazard? FindHazardById(int hazardId)
    {
        return Hazards.FirstOrDefault(h => h.Id == hazardId);
    }

    public Hazard? FindHazardAt(int x, int y)
    {
        return Hazards.FirstOrDefault(h => h.Position.X == x && h.Position.Y == y);
    }

    public Hazard? FindHazardAt(Point position)
    {
        return FindHazardAt(position.X, position.Y);
    }

    private void ReplaceCell(int x, int y, CellType newType)
    {
        Point position = new Point(x, y);

        ValidateInBounds(position);

        RemoveHazardAt(position);
        CurrentGrid.SetCell(position, newType);
    }

    private void RemoveHazardAt(Point position)
    {
        Hazards.RemoveAll(h => h.Position == position);
    }

    private void ValidateInBounds(Point position)
    {
        if (!CurrentGrid.InBounds(position))
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is outside the grid bounds.");
        }
    }
}