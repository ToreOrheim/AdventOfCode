namespace adventofcode;

public static class KitchenInventoryManagement
{
    public static long CountFreshIngredients(long[][] freshIdRanges, long[] ingredientIds)
    {
        return ingredientIds.Count(id =>
            freshIdRanges.Any(range =>
                id >= range.First() && id <= range.Last()));
    }
}
