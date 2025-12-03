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
}
