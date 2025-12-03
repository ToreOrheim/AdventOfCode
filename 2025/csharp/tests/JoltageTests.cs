using adventofcode;

namespace Joltage;

public class JoltageTests
{
    [Theory]
    [InlineData("987654321111111", 9)]
    [InlineData("811111111111119", 9)]
    [InlineData("234234234234278", 8)]
    [InlineData("818181911112111", 9)]
    public void LargestJoltageRating(string batteryBank, int expectedJoltageRating)
    {
        var (actualJoltageRating, _) = BatteryBankAnalyzer.FindLargestNumberInBank(batteryBank);

        Assert.Equal(expectedJoltageRating, actualJoltageRating);
    }

    [Theory]
    [InlineData("987654321111111", 98)]
    [InlineData("811111111111119", 89)]
    [InlineData("234234234234278", 78)]
    [InlineData("818181911112111", 92)]
    public void JoltageRating(string batteryBank, int expectedJoltageRating)
    {
        var actualJoltageRating = BatteryBankAnalyzer.JoltageRating(batteryBank);

        Assert.Equal(expectedJoltageRating, actualJoltageRating);
    }

    [Fact]
    public void TotalJoltageRating()
    {
        IEnumerable<string> batteryBanks = ["987654321111111", "811111111111119", "234234234234278", "818181911112111"];

        var actualSum = BatteryBankAnalyzer.GetTotalJoltageRating(batteryBanks);

        Assert.Equal(357, actualSum);
    }
}
