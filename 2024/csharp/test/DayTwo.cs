using REAL = AdventOfCode.Day2;

namespace test;

public class DayTwo
{
    public readonly List<List<int>> Input = [
        [7, 6, 4, 2, 1],
        [1, 2, 7, 8, 9],
        [9, 7, 6, 2, 1],
        [1, 3, 2, 4, 5],
        [8, 6, 4, 4, 1],
        [1, 3, 6, 7, 9]
    ];

    [Fact]
    public void PartOne()
    {
        var result = REAL.DayTwo.PartOne(Input);

        Assert.True(result == 2);
    }

    [Fact]
    public void PartTwo()
    {
        var result = REAL.DayTwo.PartTwo(Input);

        Assert.True(result == 4);
    }
}
