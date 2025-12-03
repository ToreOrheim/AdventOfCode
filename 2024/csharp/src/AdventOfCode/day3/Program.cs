using System.Text.RegularExpressions;

namespace AdventOfCode.Day3;

public static class DayThree
{
    public static int PartOne(List<string> input)
    {
        var parsedData = ParseData(input);

        List<int> sum = [];
        foreach (var pair in parsedData)
        {
            sum.Add(pair[0] * pair[1]);
        }
        Console.WriteLine(sum.Count);

        return sum.Sum();
    }

    public static int PartTwo(List<string> input)
    {
        var parsedData = ParseDataConditionally(input);

        List<int> sum = [];
        foreach (var pair in parsedData)
        {
            sum.Add(pair.First() * pair.Last());
        }
        Console.WriteLine(sum.Count);

        return sum.Sum();

    }

    private static List<List<int>> ParseData(List<string> lines)
    {
        var outerPattern = """mul\(\d*,\d*\)""";
        var outerRgx = new Regex(outerPattern);

        var innerPattern = """\d+""";
        var innerRgx = new Regex(innerPattern);

        List<List<int>> data = [];
        foreach (var line in lines)
        {
            foreach (var outerMatch in outerRgx.Matches(line))
            {
                if (outerMatch is null)
                {
                    continue;
                }

                string stringedOuterMatch = outerMatch.ToString()!; // handle null properly

                List<int> innerList = [];
                foreach (var innerMatch in innerRgx.Matches(stringedOuterMatch))
                {
                    var parsed = int.Parse(innerMatch.ToString()!);
                    innerList.Add(parsed);
                }

                data.Add(innerList);
            }
        }

        return data;
    }

    private static List<List<int>> ParseDataConditionally(List<string> lines)
    {
        var dontPattern = """(don't\(\)).*""";
        var dontRgx = new Regex(dontPattern);

        var doPattern = """(do\(\)).*""";
        var doRgx = new Regex(doPattern);

        var innerPattern = """(\d+),(\d+)""";
        var innerRgx = new Regex(innerPattern);

        List<List<int>> data = [];
        foreach (var line in lines)
        {
            var workableLine = line;
            while (dontRgx.IsMatch(workableLine))
            {

                workableLine = dontRgx.Replace(workableLine, "");
            }

            Console.WriteLine($"outer: {workableLine}");
            List<int> innerList = [];
            var innerMatches = innerRgx.Matches(workableLine);

            foreach (var innerMatch in innerMatches)
            {
                if (innerMatch is null)
                {
                    Console.WriteLine($"Found no match for pattern: '{innerPattern}' in line '{workableLine}'");
                    continue;
                }

                Console.WriteLine($"inner: {innerMatch}");
                var stringedInnerMatch = innerMatch.ToString()!;
                var numCollection = stringedInnerMatch.Split(',');

                var parsed = numCollection.Select(int.Parse);
                innerList.AddRange(parsed);
            }

            data.Add(innerList);
        }

        return data;
    }
}
