namespace adventofcode;

public static class KitchenInventoryManagement
{
    public static long CountFreshIngredients(long[][] freshIdRanges, long[] ingredientIds)
    {
        var expandedIds = freshIdRanges
            .Select(idRange => GetIdRange(idRange.First(), idRange.Last()))
            .SelectMany(i => i)
            .ToHashSet();

        var ids = expandedIds.Intersect(ingredientIds);
        return ids.Count();
    }

    public static IEnumerable<long> GetIdRange(long startId, long endId)
    {
        var ids = new List<long>();
        for (long i = startId; i <= endId; i++)
        {
            ids.Add(i);
        }

        return ids;
    }
}
