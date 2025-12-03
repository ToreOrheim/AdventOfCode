using adventofcode;

namespace DialTests;

public class DialTests
{
    [Theory]
    [InlineData(-10, 40)]
    [InlineData(-50, 0)]
    [InlineData(50, 0)]
    [InlineData(-80, 70)]
    [InlineData(80, 30)]
    [InlineData(-99, 51)]
    [InlineData(150, 0)]
    [InlineData(200, 50)]
    public void Rotations(int rotation, int expectedValue)
    {
        var dial = new Dial();
        dial.Turn(rotation);

        var actualValue = dial.CurrentNumber;
        Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void Password()
    {
        IEnumerable<int> instructions = [-68, -30, 48, -5, 60, -55, -1, -99, 14, -82];
        int expectedPassword = 3;

        var dial = new Dial();
        foreach (var instruction in instructions)
        {
            dial.Turn(instruction);
        }

        var actualPassword = dial.Password;
        Assert.Equal(expectedPassword, actualPassword);
    }
}
