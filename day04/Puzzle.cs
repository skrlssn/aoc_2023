namespace aoc;

public static class Puzzle
{
    public static int GetSolutionPart1(IEnumerable<string> input)
    {
        var totalPoints = 0;
        foreach (var game in input)
        {
            var parts = game.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries);

            var winningNumbers = new string[10];
            Array.Copy(parts, 2, winningNumbers, 0, winningNumbers.Length);

            var myNumbers = new string[25];
            Array.Copy(parts, 13, myNumbers, 0, myNumbers.Length);

            int pointsInGame = myNumbers.Aggregate(0, (currentPoints, number) =>
            {
                if (winningNumbers.Contains(number))
                {
                    return currentPoints == 0 ? 1 : currentPoints * 2;
                }
                return currentPoints;
            });

            totalPoints += pointsInGame;
        }
        return totalPoints;
    }

    public static int GetSolutionPart2(IEnumerable<string> input)
    {
        throw new NotImplementedException();
    }
}