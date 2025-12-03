using adventofcode;

namespace DialTests;

public class IdCheckerTests
{
    [Theory]
    [InlineData("11", true)]
    [InlineData("1010", true)]
    [InlineData("1188511885", true)]
    [InlineData("222222", true)]
    [InlineData("446446", true)]
    [InlineData("436246", false)]
    public void InvalidIds(string id, bool valid)
    {
        var actual = IdChecker.IsInvalid(id);
        Assert.Equal(valid, actual);
    }

    [Fact]
    public void IdRange()
    {
        var expectedLength = 12;
        var actualIdRange = IdChecker.GetIdRange(11, 22);
        Assert.Equal(expectedLength, actualIdRange.Count());
    }

    [Theory]
    [InlineData(11, 22, 2)]
    [InlineData(95, 115, 1)]
    [InlineData(998, 1012, 1)]
    [InlineData(1188511880, 1188511890, 1)]
    [InlineData(1698522, 1698528, 0)]
    [InlineData(446443, 446449, 1)]
    [InlineData(38593856, 38593862, 1)]
    public void InvalidIdsInRange(long startRange, long endRange, long expectedInvalidIdCount)
    {
        var invalidIdCount = IdChecker.FindInvalidIds(startRange, endRange);
        Assert.Equal(expectedInvalidIdCount, invalidIdCount);
    }

    [Fact]
    public void SumOfInvalidIds()
    {
        var idRanges = new List<List<long>>()
        {
            new List<long>() {11, 22},
            new List<long>() {95, 115},
            new List<long>() {998, 1012},
            new List<long>() {1188511880, 1188511890},
            new List<long>() {222220, 222224},
            new List<long>() {1698522, 1698528},
            new List<long>() {446443, 446449},
            new List<long>() {38593856, 38593862}
        };

        var sumOfInvalidIds = IdChecker.SumOfInvalidIds(idRanges);
        Assert.Equal(1227775554, sumOfInvalidIds);
    }
}
