using EvacuationSimulator.Data;
using Point = EvacuationSimulator.Data.Point;

namespace EvacuationSimulator.Core;

public class Hazard
{
    public int Id { get; }
    public Point Position { get; }
    public double Severity { get; private set; }
    public double DecayRate { get; private set; }

    public Hazard(int id, Point position, double severity, double decayRate)
    {
        if (severity < 0)
            throw new ArgumentOutOfRangeException(nameof(severity), "Severity cannot be negative.");

        if (decayRate < 0)
            throw new ArgumentOutOfRangeException(nameof(decayRate), "Decay rate cannot be negative.");
        
        Id = id;
        Position = position;
        Severity = severity;
        DecayRate = decayRate;
    }

    public double CalculateRiskAt(Point cell)
    {
        int dx = cell.X - Position.X;
        int dy = cell.Y - Position.Y;
        double distance = Math.Sqrt(dx * dx + dy * dy);
        
        return Severity / Math.Pow(1 + distance, DecayRate);
    }

    public void UpdateProperties(double severity, double decayRate)
    {
        if (severity < 0)
            throw new ArgumentOutOfRangeException(nameof(severity), "Severity cannot be negative.");

        if (decayRate < 0)
            throw new ArgumentOutOfRangeException(nameof(decayRate), "Decay rate cannot be negative.");

        Severity = severity;
        DecayRate = decayRate;
    }

    public override string ToString()
    {
        return $"Hazard {Id} at {Position}, Severity={Severity}, DecayRate={DecayRate}";
    }
}