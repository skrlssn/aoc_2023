using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
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
        int result = 0;
        foreach (var line in input)
        {
            MatchCollection blues = Regex.Matches(line, @"\b\d+(?=\sblue\b)");
            MatchCollection reds = Regex.Matches(line, @"\b\d+(?=\sred\b)");
            MatchCollection greens = Regex.Matches(line, @"\b\d+(?=\sgreen\b)");

            result += MinPossible(reds) * MinPossible(blues) * MinPossible(greens);
        }
        return result;
    }

    private static int MinPossible(MatchCollection matches)
    {
        if (matches.Count > 0)
        {
            var numbers = matches
                .Cast<Match>()
                .Select(match => int.Parse(match.Value));

            if (numbers.Any())
            {
                return numbers.Max();
            }
        }
        return 0;
    }
}