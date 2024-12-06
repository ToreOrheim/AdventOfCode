using REAL = AdventOfCode.Day1;

namespace test;

public class DayOne
{
    private readonly List<List<int>> Input = [
        [3, 4, 2, 1, 3, 3],
        [4, 3, 5, 3, 9, 3]
    ];

    [Fact]
    public void PartOne()
    {
        var result = REAL.DayOne.PartOne(Input);

        Assert.True(result == 11);
    }

    [Fact]
    public void PartTwo()
    {
        var result = REAL.DayOne.PartTwo(Input);

        Assert.True(result == 31);
    }
}
