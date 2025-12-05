using adventofcode;

namespace Tests;

public class KitchenInventoryTests
{
    [Fact]
    public void IsFreshIngredient()
    {
        long[][] freshIdRanges = [[3, 5], [10, 14], [16, 20], [12, 18]];
        long[] ingredientIds = [1, 5, 8, 11, 17, 32];

        var expectedFreshIngredients = 3;

        var actualFreshIngredients = KitchenInventoryManagement.CountFreshIngredients(freshIdRanges, ingredientIds);

        Assert.Equal(expectedFreshIngredients, actualFreshIngredients);
    }

    [Fact]
    public void FreshIngredientIds()
    {
        long[][] freshIdRanges = [[3, 5], [10, 14], [16, 20], [12, 18]];

        var expectedFreshIngredientIdCount = 14;

        var actualFreshIngredientIdCount = KitchenInventoryManagement.CountFreshIngredientIds(freshIdRanges);

        Assert.Equal(expectedFreshIngredientIdCount, actualFreshIngredientIdCount);
    }
}
