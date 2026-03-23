namespace EvacuationSimulator.Data;

public class ScenarioListItem
{
    public string FilePath { get; }
    public string DisplayName { get; }

    public ScenarioListItem(string filePath, string displayName)
    {
        FilePath = filePath;
        DisplayName = displayName;
    }

    public override string ToString()
    {
        return DisplayName;
    }
}