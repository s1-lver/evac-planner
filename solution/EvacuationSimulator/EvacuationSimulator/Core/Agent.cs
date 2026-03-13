using System.ComponentModel;
using EvacuationSimulator.Data;
using Point =  EvacuationSimulator.Data.Point;

namespace EvacuationSimulator.Core;

public class Agent
{
    public int Id { get; }
    public Point Position { get; private set; }
    public List<Point> PlannedPath { get; private set; }
    public bool HasEvacuated { get; private set; }
    public int WaitingTime { get; private set; }
    public double RiskExposure { get; private set; }

    public Agent(int id, Point startPosition)
    {
        Id = id;
        Position = startPosition;
        PlannedPath = new List<Point>();
        HasEvacuated = false;
        WaitingTime = 0;
        RiskExposure = 0;
    }

    public void SetPath(List<Point> path)
    {
        PlannedPath = new List<Point>(path);
        
        while (PlannedPath.Count > 0 && PlannedPath[0] == Position)
            PlannedPath.RemoveAt(0);
    }

    public Point? ChooseNextMove()
    {
        if (HasEvacuated)
            return null;
        if (PlannedPath.Count == 0)
            return null;

        return PlannedPath[0];
    }

    public void MoveTo(Point nextCell)
    {
        if (HasEvacuated)
            throw new InvalidOperationException("Evacuated agents cannot move.");

        Position = nextCell;
        
        if (PlannedPath.Count > 0 && PlannedPath[0] == nextCell) 
            PlannedPath.RemoveAt(0);
    }

    public void Wait()
    {
        if (!HasEvacuated)
            WaitingTime++;
    }

    public void AddRiskExposure(double risk)
    {
        if (risk < 0)
            throw new ArgumentOutOfRangeException(nameof(risk), "Risk cannot be negative.");

        if (!HasEvacuated)
            RiskExposure += risk;
    }

    public void MarkEvacuated()
    {
        HasEvacuated = true;
        PlannedPath.Clear();
    }

    public void Reset(Point startPosition)
    {
        Position = startPosition;
        PlannedPath.Clear();
        HasEvacuated = false;
        WaitingTime = 0;
        RiskExposure = 0;
    }

    public override string ToString()
    {
        return $"Agent {Id} at {Position}, Evacuated={HasEvacuated}, Waiting={WaitingTime}, Risk={RiskExposure:F2}";
    }
}