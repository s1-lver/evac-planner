using EvacuationSimulator.Data;
using Point = EvacuationSimulator.Data.Point;

namespace EvacuationSimulator.Core;

public class ExampleScenario
{
    public string Name { get; }
    public int Width { get; }
    public int Height { get; }
    
    public List<Point> Walls { get; }
    public List<Point> Exits { get; }
    public List<Point> Spawns { get; }
    public List<ExampleHazard> Hazards { get; }
    
    public ExampleScenario(
        string name,
        int width,
        int height,
        List<Point> walls,
        List<Point> exits,
        List<Point> spawns,
        List<ExampleHazard> hazards)
    {
        Name = name;
        Width = width;
        Height = height;
        Walls = walls;
        Exits = exits;
        Spawns = spawns;
        Hazards = hazards;
    }

    public override string ToString()
    {
        return Name;
    }
}