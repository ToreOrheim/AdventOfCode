namespace _2024.FileParsing;

public static class FileParser
{
    public static List<List<int>> ParseCSVColumns(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        List<int> columnOne = [];
        List<int> columnTwo = [];
        foreach (var line in lines)
        {
            var fields = line.Split(';');
            columnOne.Add(int.Parse(fields[0]));
            columnTwo.Add(int.Parse(fields[1]));
        }

        List<List<int>> columns = [columnOne, columnTwo];

        return columns;
    }
}
