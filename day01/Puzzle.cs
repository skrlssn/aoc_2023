namespace aoc;

public static class Puzzle
{
    public static int GetSolutionPart1(IEnumerable<string> input)
    {
        var allDigits = new List<int>();
        foreach (var row in input)
        {
            var firstDigit = row.FirstOrDefault(c => int.TryParse(c.ToString(), out _));
            var lastDigit = row.LastOrDefault(c => int.TryParse(c.ToString(), out _));

            allDigits.Add(int.Parse(firstDigit.ToString() + lastDigit.ToString()));
        }
        return allDigits.Sum();
    }

    public static int GetSolutionPart2(IEnumerable<string> input)
    {
        return 1;
    }
}