namespace AdventOfCode.Day2;

public static class DayTwo
{
    public static int PartOne(List<List<int>> input)
    {
        var safeReports = GetSafeReports(input);

        return safeReports;
    }

    public static int PartTwo(List<List<int>> input)
    {
        var safeReports = GetSafeReports(input);
        return safeReports;
    }

    private static int GetSafeReports(List<List<int>> input, bool useDampener = false)
    {
        int safeReports = 0;
        foreach (var line in input)
        {
            var isSafe = useDampener ? CalculateIfReportIsSafeWithDampener(line) : CalculateIfReportIsSafe(line);

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
        return line != null;
    }
}
