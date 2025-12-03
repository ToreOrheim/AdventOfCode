namespace adventofcode;

public class Dial
{
    public int CurrentNumber { get; set; } = 50;

    private readonly int SecretMarker = 0;

    public int Password = 0;

    public int Turn(int rotations)
    {
        int temporaryValue = CurrentNumber + rotations;

        CurrentNumber = HandleOverflow(temporaryValue);

        CheckForSecretMarker();

        return CurrentNumber;
    }

    // WTF is this
    private static int HandleOverflow(int value)
        => (value % 100 + 100) % 100;

    private void CheckForSecretMarker()
    {
        if (CurrentNumber == SecretMarker)
            Password++;
    }
}
