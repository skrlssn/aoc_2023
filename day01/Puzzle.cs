using System.Text.RegularExpressions;

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
        string pattern = @"(?:[1-9]|one|two|three|four|five|six|seven|eight|nine)";

        Regex regexFirst = new Regex(pattern);
        Regex regexLast = new Regex(pattern, RegexOptions.RightToLeft);

        Dictionary<string, string> numberDict = new Dictionary<string, string>
        {
            {"one", "1"},
            {"two", "2"},
            {"three", "3"},
            {"four", "4"},
            {"five", "5"},
            {"six", "6"},
            {"seven", "7"},
            {"eight", "8"},
            {"nine", "9"}
        };

        var result = new List<int>();

        foreach (var row in input)
        {
            MatchCollection matchesFromLeft = regexFirst.Matches(row);
            MatchCollection matchesFromRight = regexLast.Matches(row);

            string firstDigit = matchesFromLeft.First().ToString();
            string lastDigit = matchesFromRight.First().ToString();

            if (numberDict.TryGetValue(firstDigit, out string? firstValue))
            {
                firstDigit = firstValue;
            }

            if (numberDict.TryGetValue(lastDigit, out string? lastValue))
            {
                lastDigit = lastValue;
            }

            int number = int.Parse(firstDigit + lastDigit);

            result.Add(number);
        }
        return result.Sum();
    }
}
