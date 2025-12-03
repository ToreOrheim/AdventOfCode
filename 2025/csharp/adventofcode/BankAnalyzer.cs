namespace adventofcode;

public static class BatteryBankAnalyzer
{
    // Yikes this is some ugly ass fkin code
    public static int JoltageRating(string batteryBank)
    {
        var (firstJoltageRating, firstBattery) = FindLargestNumberInBank(batteryBank);
        if (firstBattery + 1 != batteryBank.Length)
        {
            var mod = batteryBank.Substring(firstBattery);
            var (secondJoltage, _) = FindLargestNumberInBank(mod, 0);
            return int.Parse(string.Join("", [$"{firstJoltageRating}", $"{secondJoltage}"]));
        }

        var (secondJoltageRating, _) = FindLargestNumberInBank(batteryBank, firstBattery);
        if (firstBattery + 1 == batteryBank.Length)
        {
            return int.Parse(string.Join("", [$"{secondJoltageRating}", $"{firstJoltageRating}"]));
        }

        return int.Parse(string.Join("", [$"{firstJoltageRating}", $"{secondJoltageRating}"]));
    }

    public static (int joltage, int fountAtIndex) FindLargestNumberInBank(string batteryBank, int? ignoreIndex = null)
    {
        int largestJoltageRating = 0;
        int battery = 0;
        for (int i = 0; i < batteryBank.Length; i++)
        {
            if (ignoreIndex == null || ignoreIndex != i)
            {

                var joltRating = int.Parse(batteryBank[i].ToString());
                if (largestJoltageRating < joltRating)
                {
                    largestJoltageRating = joltRating;
                    battery = i;
                }
            }
        }

        return (largestJoltageRating, battery);
    }

    public static int GetTotalJoltageRating(IEnumerable<string> batteryBanks)
    {
        var sum = 0;
        foreach (var batteryBank in batteryBanks)
        {
            sum += JoltageRating(batteryBank);
        }

        return sum;
    }
}
