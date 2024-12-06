using AdventOfCode.Day1;
using AdventOfCode.Day2;
using AdventOfCode.FileParsing;

namespace AdventOfCode;

class Program
{
    static void Main()
    {
        Console.WriteLine("DayOne:");
        Console.WriteLine($"Part1 = '{DayOne.PartOne(FileParser.ParseCSVColumns("src/AdventOfCode/day1/input.csv"))}'");
        Console.WriteLine($"Part2 = '{DayOne.PartTwo(FileParser.ParseCSVColumns("src/AdventOfCode/day1/input.csv"))}'");
        Console.WriteLine("-------------------------- - ");
        Console.WriteLine("DayTwo:");
        Console.WriteLine($"Part1 = '{DayTwo.PartOne(FileParser.ParseCSVReport("src/AdventOfCode/day2/input.csv"))}'");
        Console.WriteLine($"Part2 = '{DayTwo.PartTwo(FileParser.ParseCSVReport("src/AdventOfCode/day2/input.csv"))}'");
        Console.WriteLine("---------------------------");
    }
}
