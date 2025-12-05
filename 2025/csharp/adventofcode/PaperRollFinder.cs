namespace adventofcode;

public static class PaperRollFinder
{
    public static int FindAccessiblePaperRoll(char[][] map)
    {
        var availablePaperRolls = 0;
        for (var i = 0; i < map.Length; i++)
        {
            var row = map[i];
            for (var j = 0; j < row.Length; j++)
            {
                if (map[i][j] is '.')
                    continue;

                List<char> surroundingChars = [];
                if (i != 0)
                {
                    if (j != 0)
                    {
                        surroundingChars.Add(map[i - 1][j - 1]);
                    }
                    surroundingChars.Add(map[i - 1][j]);
                    if (j != row.Length - 1)
                    {
                        surroundingChars.Add(map[i - 1][j + 1]);
                    }
                }

                // --------

                if (j != 0)
                {
                    surroundingChars.Add(map[i][j - 1]);
                }
                // We don't add the current char as it is not adjacent
                if (j != row.Length - 1)
                {
                    surroundingChars.Add(map[i][j + 1]);
                }

                // --------

                if (i != map.Length - 1)
                {
                    if (j != 0)
                    {
                        surroundingChars.Add(map[i + 1][j - 1]);
                    }
                    surroundingChars.Add(map[i + 1][j]);
                    if (j != row.Length - 1)
                    {
                        surroundingChars.Add(map[i + 1][j + 1]);
                    }
                }
                var countAdjacentPaper = surroundingChars.FindAll(s => s is '@').Count;

                if (countAdjacentPaper < 4)
                {
                    availablePaperRolls++;
                }
            }
        }
        return availablePaperRolls;
    }
}
