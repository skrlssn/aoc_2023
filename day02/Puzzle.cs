using System.Text.RegularExpressions;

namespace aoc;

public static class Puzzle
{
    public static int GetSolutionPart1(IEnumerable<string> input)
    {
        int gameId = 0;
        int sum = 0;
        foreach (var line in input)
        {
            gameId++;
            if (Regex.IsMatch(line, @"\b(?:1[3-9]|[2-9]\d+)\sred\b")
            || Regex.IsMatch(line, @"\b(?:1[4-9]|[2-9]\d+)\sgreen\b")
            || Regex.IsMatch(line, @"\b(?:1[5-9]|[2-9]\d+)\sblue\b"))
            {
                continue;
            }
            sum += gameId;
        }
        return sum;
    }

    public static int GetSolutionPart2(IEnumerable<string> input)
    {
        throw new NotImplementedException();
    }
}