using adventofcode;

namespace Tests;

public class AccessiblePaperRollsTests
{
    [Fact]
    public void FindAccessibleRolls()
    {
        string[] paperRollMap = [
            "..@@.@@@@.",
            "@@@.@.@.@@",
            "@@@@@.@.@@",
            "@.@@@@..@.",
            "@@.@@@@.@@",
            ".@@@@@@@.@",
            ".@.@.@.@@@",
            "@.@@@.@@@@",
            ".@@@@@@@@.",
            "@.@.@@@.@."];

        var map = paperRollMap.Select(row => row.ToCharArray()).ToArray();
        var amountOfAccessiblePaperRolls = PaperRollFinder.FindAccessiblePaperRoll(map);

        Assert.Equal(13, amountOfAccessiblePaperRolls);
    }
}
