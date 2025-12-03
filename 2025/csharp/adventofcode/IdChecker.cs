using System.Text.RegularExpressions;

namespace adventofcode;

public class IdChecker
{
    public static bool IsInvalid(string id)
    {
        // Match multiple patterns of any characeters
        var regEx = new Regex(@"^(.+)\1$");
        var match = regEx.Match(id);

        // If we have a match, the ID is not valid
        return match.Success;
    }

    public static IEnumerable<string> GetIdRange(long startId, long endId)
    {
        var ids = new List<string>();
        for (long i = startId; i <= endId; i++)
        {
            ids.Add(i.ToString());
        }

        return ids;
    }

    public static long FindInvalidIds(long startId, long endId)
    {
        var idRange = GetIdRange(startId, endId);

        long invalidIdCount = 0;
        foreach (var id in idRange)
        {
            bool invalidId = IsInvalid(id);
            if (IsInvalid(id))
                invalidIdCount++;
        }

        return invalidIdCount;
    }


    public static long SumOfInvalidIds(IEnumerable<IEnumerable<long>> rangesOfIds)
    {
        long sum = 0;
        foreach (var rangeOfIds in rangesOfIds)
        {
            var idRange = GetIdRange(rangeOfIds.First(), rangeOfIds.Last());
            foreach (var id in idRange)
            {
                if (IsInvalid(id))
                    sum += long.Parse(id);
            }
        }
        return sum;
    }
}
