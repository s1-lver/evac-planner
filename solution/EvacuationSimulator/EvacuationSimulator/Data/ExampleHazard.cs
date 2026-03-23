namespace EvacuationSimulator.Data;

public record ExampleHazard
{
    public string Key { get; }
    public Point Position { get; }
    public double Severity { get; }
    public double DecayRate { get; }

    public ExampleHazard(string key, Point position, double severity, double decayRate)
    {
        Key = key;
        Position = position;
        Severity = severity;
        DecayRate = decayRate;
    }
};