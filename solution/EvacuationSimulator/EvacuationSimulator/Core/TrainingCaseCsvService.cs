using System.Globalization;
using EvacuationSimulator.Data;

namespace EvacuationSimulator.Core;

public class TrainingCaseCsvService
{
    public void Save(string filePath, List<TrainingCase> trainingCases)
    {
        if (trainingCases is null) 
            throw new ArgumentNullException(nameof(trainingCases));

        string? directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrWhiteSpace(directory))
            Directory.CreateDirectory(directory);
        
        using StreamWriter writer = new StreamWriter(filePath, false);
        
        writer.WriteLine("ScenarioName,GridWidth,GridHeight,AgentCount,ExitCount,HazardCount,AverageHazardSeverity,ObstacleDensity,MinSpawnToHazardDistance,MinExitToHazardDistance,BestAlgorithm");
        foreach (TrainingCase trainingCase in trainingCases)
        {
            ScenarioFeatures features = trainingCase.Features;

            writer.WriteLine(string.Join(",",
                Sanitize(trainingCase.ScenarioName),
                features.GridWidth.ToString(CultureInfo.InvariantCulture),
                features.GridHeight.ToString(CultureInfo.InvariantCulture),
                features.AgentCount.ToString(CultureInfo.InvariantCulture),
                features.ExitCount.ToString(CultureInfo.InvariantCulture),
                features.HazardCount.ToString(CultureInfo.InvariantCulture),
                features.AverageHazardSeverity.ToString(CultureInfo.InvariantCulture),
                features.ObstacleDensity.ToString(CultureInfo.InvariantCulture),
                features.MinSpawnToHazardDistance.ToString(CultureInfo.InvariantCulture),
                features.MinExitToHazardDistance.ToString(CultureInfo.InvariantCulture),
                trainingCase.BestAlgorithm.ToString()));
        }
    }

    public List<TrainingCase> Load(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Training CSV file not found.", filePath);

        string[] lines = File.ReadAllLines(filePath);

        if (lines.Length <= 1)
            return new List<TrainingCase>();

        List<TrainingCase> trainingCases = new();

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i].Trim();

            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split(',', StringSplitOptions.TrimEntries);

            if (parts.Length != 11)
                throw new InvalidDataException($"Invalid training row on line {i + 1}: '{line}'.");

            string scenarioName = parts[0];

            ScenarioFeatures features = new ScenarioFeatures(
                int.Parse(parts[1], CultureInfo.InvariantCulture),
                int.Parse(parts[2], CultureInfo.InvariantCulture),
                int.Parse(parts[3], CultureInfo.InvariantCulture),
                int.Parse(parts[4], CultureInfo.InvariantCulture),
                int.Parse(parts[5], CultureInfo.InvariantCulture),
                double.Parse(parts[6], CultureInfo.InvariantCulture),
                double.Parse(parts[7], CultureInfo.InvariantCulture),
                double.Parse(parts[8], CultureInfo.InvariantCulture),
                double.Parse(parts[9], CultureInfo.InvariantCulture));

            RoutingAlgorithm bestAlgorithm = Enum.Parse<RoutingAlgorithm>(parts[10]);
            
            trainingCases.Add(new TrainingCase(scenarioName, features, bestAlgorithm));
        }

        return trainingCases;
    }

    private string Sanitize(string value)
    {
        return value.Replace(",", " ");
    }
}