using adventofcode;

namespace Tests;

public class TrashMathTests
{
    [Theory]
    [InlineData(33210L, '*', 123L, 45L, 6L)]
    [InlineData(490L, '+', 328L, 64L, 98L)]
    [InlineData(4243455L, '*', 51L, 387L, 215L)]
    [InlineData(401L, '+', 64L, 23L, 314L)]
    public void SolveMathProblem(long expectedSolution, char mathOperation, params long[] numbers)
    {
        var actualSolution = TrashMath.Solve(mathOperation, numbers);

        Assert.Equal(expectedSolution, actualSolution);
    }

    [Fact]
    public void SumOfAllProblems()
    {

        (char operation, long[] problem)[] input = [('*', [123L, 45L, 6L]), ('+', [328L, 64L, 98L]), ('*', [51L, 387L, 215L]), ('+', [64L, 23L, 314L])];
        long expectedSolution = 4277556;

        var actualSolution = TrashMath.GetSolution(input);

        Assert.Equal(expectedSolution, actualSolution);
    }
}
