using _2024.FileParsing;

namespace _2024.Day1;

public static class DayOne
{
    public static int PartOne()
    {
        var (input1, input2) = GetSortedInput();
        var distanceBetween = CalculateDifferencesBetweenListsOfInts(input1, input2);

        var sumOfDifferences = distanceBetween.Sum();

        return sumOfDifferences;
    }

    public static int PartTwo()
    {
        var (input1, input2) = GetSortedInput();
        var similarityScore = CalculateSimilarityScore(input1, input2);

        var sumOfDifferences = similarityScore.Sum();

        return sumOfDifferences;
    }

    private static (List<int> i1, List<int> i2) GetSortedInput()
    {
        var input = FileParser.ParseCSVColumns("day1/input.csv");

        List<int> historianListOne = input.First();
        List<int> historianListTwo = input.Last();

        historianListOne.Sort((x, y) => x - y);
        historianListTwo.Sort((x, y) => x - y);

        return (historianListOne, historianListTwo);
    }

    private static List<int> CalculateDifferencesBetweenListsOfInts(List<int> l1, List<int> l2)
    {
        List<int> distanceBetweenIndices = [];

        for (int i = 0; i < l1.Count; i++)
        {
            var distanceBetweenNumbers = Math.Abs(l1[i] - l2[i]);
            distanceBetweenIndices.Add(distanceBetweenNumbers);
        }

        return distanceBetweenIndices;
    }

    private static List<int> CalculateSimilarityScore(List<int> l1, List<int> l2)
    {
        List<int> similarityList = [];
        foreach (var n in l1)
        {
            var timesInl2 = l2.FindAll(x => x == n).Count;
            var similarity = n * timesInl2;

            similarityList.Add(similarity);
        }

        return similarityList;
    }
}

