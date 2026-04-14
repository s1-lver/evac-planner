using System.Globalization;
using EvacuationSimulator.Data;
using Point = EvacuationSimulator.Data.Point;

namespace EvacuationSimulator.Core;

public class ExampleScenarioLoader
{
    public ExampleScenario LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Scenario file not found.", filePath);

        List<string> allLines = File.ReadAllLines(filePath)
            .Select(line => line.Trim())
            .ToList();

        List<string> filteredLines = allLines
            .Where(line => !string.IsNullOrWhiteSpace(line) || allLines.Contains(string.Empty))
            .ToList();

        List<string> gridLines = new();
        List<string> hazardLines = new();

        bool readingHazards = false;

        foreach (string rawLine in allLines)
        {
            string line = rawLine.Trim();

            if (string.IsNullOrWhiteSpace(line))
            {
                if (gridLines.Count > 0)
                    readingHazards = true;

                continue;
            }

            if (line.StartsWith("//"))
                continue;
            
            if (!readingHazards)
                gridLines.Add(line);
            else
                hazardLines.Add(line);
        }

        if (gridLines.Count == 0)
            throw new InvalidDataException("Scenario file contains no grid data.");

        List<string[]> tokenRows = gridLines
            .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .ToList();

        int width = tokenRows[0].Length;
        int height = tokenRows.Count;

        if (width == 0)
            throw new InvalidDataException("Scenario width cannot be zero.");

        if (tokenRows.Any(row => row.Length != width))
            throw new InvalidDataException("All grid rows must have the same number of tokens.");

        Dictionary<string, (double Severity, double DecayRate)> hazardDefinitions =
            ParseHazardDefinitions(hazardLines);

        List<Point> walls = new();
        List<Point> spawns = new();
        List<Point> exits = new();
        List<(string Key, Point position)> hazardReferences = new();

        HashSet<string> seenHazardKeysInGrid = new();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                string token = tokenRows[y][x];

                switch (token)
                {
                    case "#":
                        walls.Add(new Point(x, y));
                        break;
                    case ".":
                        break;
                    case "S":
                        spawns.Add(new Point(x, y));
                        break;
                    case "E":
                        exits.Add(new Point(x, y));
                        break;
                    default:
                        if (IsHazardToken(token))
                        {
                            if (!seenHazardKeysInGrid.Add(token))
                                throw new InvalidDataException(
                                    $"Hazard token {token} appears more than once in the grid.");
                            
                            hazardReferences.Add((token, new Point(x, y)));
                        }
                        else
                        {
                            throw new InvalidDataException($"Unsupported grid token {token} at ({x}, {y}).");
                        }

                        break;
                }
            }
        }

        List<ExampleHazard> hazards = new();

        foreach ((string key, Point position) in hazardReferences)
        {
            if (!hazardDefinitions.TryGetValue(key, out (double Severity, double DecayRate) definition))
                throw new InvalidDataException($"Hazard {key} is used in grid but has no definition.");
            
            hazards.Add(new ExampleHazard(key, position, definition.Severity, definition.DecayRate));
        }

        string name = Path.GetFileNameWithoutExtension(filePath);

        return new ExampleScenario(name, width, height, walls, exits, spawns, hazards);
    }

    public List<string> GetScenarioFiles(string folderPath)
    {
        if (!Directory.Exists(folderPath))
            return new List<string>();

        if (Directory.Exists(folderPath + "\\TrainingEvaluation"))
            return Directory.GetFiles(folderPath, "*.evac")
                .Concat(
                    Directory.GetFiles(folderPath + "\\TrainingEvaluation", "*.evac"))
                .OrderBy(path => path)
                .ToList();
        
        return Directory.GetFiles(folderPath, "*.evac")
            .OrderBy(path => path)
            .ToList(); 
    }

    private Dictionary<string, (double Severity, double DecayRate)> ParseHazardDefinitions(List<string> hazardLines)
    {
        Dictionary<string, (double Severity, double DecayRate)> definitions = new();

        foreach (string line in hazardLines)
        {
            string[] parts = line.Split(',', StringSplitOptions.TrimEntries |
                                             StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 3)
                throw new InvalidDataException($"Invalid hazard definition line: {line}.");

            string key = parts[0];

            if (!IsHazardToken(key))
                throw new InvalidDataException($"Invalid hazard key {key}.");

            if (!double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double severity))
                throw new InvalidDataException($"Invalid severity for hazard {key}.");
            
            if (!double.TryParse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double decayRate))
                throw new InvalidDataException($"Invalid decay rate for hazard {key}.");

            if (definitions.ContainsKey(key))
                throw new InvalidDataException($"Duplicate hazard definitions for {key}.");

            definitions[key] = (severity, decayRate);
        }
        
        return definitions;
    }

    private bool IsHazardToken(string token)
    {
        return token.Length >= 2
               && token[0] == 'H'
               && token.Skip(1).All(char.IsDigit);
    }
}