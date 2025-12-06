namespace IO;

public static class FileHandler
{
    public static IEnumerable<int> ReadDialInstructions(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        List<int> parsedInstructions = [];
        foreach (var line in lines)
        {
            if (line.StartsWith('L'))
            {
                var subtractionInstruction = -int.Parse(line.Substring(1));
                parsedInstructions.Add(subtractionInstruction);
            }
            else if (line.StartsWith('R'))
            {
                var additionInstruction = int.Parse(line.Substring(1));
                parsedInstructions.Add(additionInstruction);
            }
            else
            {
                throw new Exception($"Can not parse line: '{line}'");
            }
        }

        return parsedInstructions;
    }

    public static IEnumerable<IEnumerable<long>> ReadProductIdRanges(string filePath)
    {
        var line = File.ReadLines(filePath).First();
        var idRanges = line.Split(',').Select(idRange => idRange.Split('-').Select(s => long.Parse(s)));

        return idRanges;
    }

    public static IEnumerable<string> ReadBatteryBanks(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        return lines;
    }

    public static Char[][] ReadPaperRollMap(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        return [.. lines.Select(l => l.ToCharArray())];
    }

    public static (long[][] freshIdRanges, long[] ingredientIds) ReadKitchenIngredientDatabase(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        // Find the line that seperates freshIngredientRangeLines from ingredientIdLines
        int emptyLine = Array.IndexOf(lines, "");

        // Split lines on the seperator, first is freshIdRanges, second is ingredientIds
        var freshIngredientIdRangeLines = lines[..emptyLine];
        var ingredientIdLines = lines[(emptyLine + 1)..];

        // Parse freshIdRanges
        long[][] parsedFreshIngredientIdRanges = freshIngredientIdRangeLines
            .Select(idRange => idRange.Split('-').Select(long.Parse).ToArray())
            .ToArray();

        // Parse individual ingredient IDs
        long[] parsedIngredientIds = ingredientIdLines
            // We crashed without checking ^_^
            .Where(ingredientId => !string.IsNullOrWhiteSpace(ingredientId))
            .Select(long.Parse)
            .ToArray();

        return (parsedFreshIngredientIdRanges, parsedIngredientIds);
    }

    public static (char operation, long[] numbers)[] ReadTrashMathProblems(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        // Find out how many lines
        var lineCount = lines.Length;

        // It works but... yikes
        var numberLines = lines.SkipLast(2).Select(line => line.Split(null).Where(s => !string.IsNullOrWhiteSpace(s)).Select(long.Parse).ToArray()).ToArray();
        var operations = lines.SkipLast(1).Last().Split(null).Where(s => !string.IsNullOrWhiteSpace(s)).Select(char.Parse).ToArray();

        // Create an entry in the tuple list for every operation we have
        List<(char operation, List<long> numbers)> problems =
            operations.Select(op => (op, new List<long>())).ToList();

        // Loop through our numbers and assign the columns to the correct tuple numbers array
        for (int i = 0; i < numberLines.Length; i++)
        {
            for (int j = 0; j < numberLines[i].Length; j++)
            {
                problems[j].numbers.Add(numberLines[i][j]);
            }
        }

        return problems.Select(problem => (problem.operation, problem.numbers.ToArray())).ToArray();
    }
}
