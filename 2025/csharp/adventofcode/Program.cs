using IO;

namespace adventofcode;

class Program
{
    static void Main(string[] args)
    {
        GetPassword();
        //GetSumOfAllInvalidIds();
        GetTotalJoltageBattery();
        GetAccessiblePaperRolls();
        GetFreshIngredients();
    }

    public static void GetPassword()
    {
        var instructions = FileHandler.ReadDialInstructions("input/Day1Input.txt");

        var dial = new Dial();
        foreach (var instruction in instructions)
        {
            dial.Turn(instruction);
        }

        Console.WriteLine($"Password {dial.Password}");
    }

    public static void GetSumOfAllInvalidIds()
    {
        var idRanges = FileHandler.ReadProductIdRanges("input/Day2Input.txt");
        var sum = IdChecker.SumOfInvalidIds(idRanges);
        Console.WriteLine($"Sum of invalid ids: {sum}");
    }

    public static void GetTotalJoltageBattery()
    {
        var batteryBanks = FileHandler.ReadBatteryBanks("input/Day3Input.txt");
        var sum = BatteryBankAnalyzer.GetTotalJoltageRating(batteryBanks);
        Console.WriteLine($"Total output joltage: {sum}");
    }

    public static void GetAccessiblePaperRolls()
    {
        var paperRollMap = FileHandler.ReadPaperRollMap("input/Day4Input.txt");
        var availablePaperRolls = PaperRollFinder.FindAccessiblePaperRoll(paperRollMap);
        Console.WriteLine($"Available paper rolls: {availablePaperRolls}");
    }

    public static void GetFreshIngredients()
    {
        var (freshIdRanges, ingredientIds) = FileHandler.ReadKitchenIngredientDatabase("input/Day5Input.txt");
        var countFreshIngredients = KitchenInventoryManagement.CountFreshIngredients(freshIdRanges, ingredientIds);
        Console.WriteLine($"Fresh ingredients: {countFreshIngredients}");
    }
}
