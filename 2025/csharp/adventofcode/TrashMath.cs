namespace adventofcode;

public static class TrashMath
{
    public static long Solve(char operation, long[] numbers)
        => operation switch
        {
            '*' => Multiply(numbers),
            '+' => Add(numbers),
            _ => throw new InvalidOperationException($"Operation '{operation}', is not supported")
        };

    private static long Multiply(long[] numbers)
        => numbers.Aggregate(1, (long x, long y) => x * y);

    private static long Add(long[] numbers)
        => numbers.Sum();

    public static long GetSolution((char operation, long[] numbers)[] problems)
        => problems.Sum(problem => Solve(problem.operation, problem.numbers));
}
