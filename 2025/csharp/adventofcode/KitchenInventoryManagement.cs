namespace adventofcode;

public static class KitchenInventoryManagement
{
    public static long CountFreshIngredients(long[][] freshIdRanges, long[] ingredientIds)
    {
        return ingredientIds.Count(id =>
            freshIdRanges.Any(range =>
                id >= range.First() && id <= range.Last()));
    }

    public static long CountFreshIngredientIds(long[][] freshIdRanges)
    {
        var idRanges = freshIdRanges.OrderBy(idRange => idRange[0]).ToList();
        long countFreshIds = 0;
        long currentIdRangeStart = idRanges[0][0];
        long currentIdRangeEnd = idRanges[0][1];

        foreach (var idRange in idRanges)
        {
            // We don't care about the first since we have that in "state" above
            if (idRange == idRanges[0])
                continue;

            // If the id of the range we are in, is less or eaqual to the last loaded idRange[1]
            // Merge the ranges
            if (idRange[0] <= currentIdRangeEnd + 1)
            {
                currentIdRangeEnd = Math.Max(currentIdRangeEnd, idRange[1]);
            }
            // Otherwise, we count the amount of valid ids in our current "state"
            // Then set a new "state"
            else
            {
                countFreshIds += currentIdRangeEnd - currentIdRangeStart + 1;
                currentIdRangeStart = idRange[0];
                currentIdRangeEnd = idRange[1];
            }
        }

        countFreshIds += currentIdRangeEnd - currentIdRangeStart + 1;
        return countFreshIds;
    }
}
