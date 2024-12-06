using AdventOfCode.FileParsing;

namespace AdventOfCode.Day2;

public static class DayTwo
{
    public static int PartOne()
    {
        var input = GetInput();

        var safeReports = GetSafeReports(input);

        return safeReports;
    }

    public static int PartTwo()
    {
        var input = GetInput();
        var safeReports = GetSafeReportsWithDampener(input);
        return safeReports;
    }

    private static List<List<int>> GetInput() =>
        FileParser.ParseCSVReport("day2/input.csv");

    private static int GetSafeReports(List<List<int>> input)
    {
        int safeReports = 0;
        foreach (var line in input)
        {
            var isSafe = CalculateIfReportIsSafe(line);

            if (isSafe) safeReports++;
        }

        return safeReports;
    }

    private static int GetSafeReportsWithDampener(List<List<int>> input)
    {
        int safeReports = 0;
        foreach (var line in input)
        {
            var isSafe = CalculateIfReportIsSafeWithDampener(line);

            if (isSafe) safeReports++;
        }

        return safeReports;
    }

    private static bool CalculateIfReportIsSafe(List<int> line)
    {
        bool isSafe = true;
        bool? previouslyIncreasing = null;
        for (int i = 0; i < line.Count - 1; i++)
        {
            var num1 = line[i]; // 7
            var num2 = line[i + 1]; // 4

            var diff = num2 - num1; // 4 - 7 = -3
            var currentlyIncreasing = int.IsPositive(diff);

            if (Math.Abs(diff) > 3 || Math.Abs(diff) == 0)
            {
                isSafe = false;
            }

            if (previouslyIncreasing is null)
            {
                previouslyIncreasing = currentlyIncreasing;
                continue;
            }

            if (previouslyIncreasing != currentlyIncreasing)
            {
                isSafe = false;
            }
        }

        return isSafe;
    }

    private static bool CalculateIfReportIsSafeWithDampener(List<int> line)
    {
        bool? previouslyIncreasing = null;
        int countUnsafe = 0;
        for (int i = 0; i < line.Count - 1; i++)
        {
            var num1 = line[i]; // 7
            var num2 = line[i + 1]; // 4

            var diff = num2 - num1; // 4 - 7 = -3
            var currentlyIncreasing = int.IsPositive(diff);

            if (Math.Abs(diff) > 3 || Math.Abs(diff) == 0)
            {
                countUnsafe++;
                continue;
            }

            if (previouslyIncreasing is null)
            {
                previouslyIncreasing = currentlyIncreasing;
                continue;
            }

            if (previouslyIncreasing != currentlyIncreasing)
            {
                countUnsafe++;
                continue;
            }
        }

        return !(countUnsafe > 1);
    }
}
