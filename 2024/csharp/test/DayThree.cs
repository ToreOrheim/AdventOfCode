using REAL = AdventOfCode.Day3;

namespace test;

public class DayThree
{
    public readonly List<string> Input = [
        "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"
    ];

    [Fact]
    public void PartOne()
    {
        var expected = 161;
        var result = REAL.DayThree.PartOne(Input);

        Assert.True(result == expected, $"Expected value of {expected}, but received {result}");
    }

    [Fact]
    public void PartTwo()
    {
        var expected = 48;
        var result = REAL.DayThree.PartTwo(Input);

        Assert.True(result == expected, $"Expected value of {expected}, but received {result}");
    }
}
