using System.Runtime.CompilerServices;
using System.Security.Principal;
using Xunit.Sdk;

namespace aoc;

public static class Puzzle
{
    public static int GetSolutionPart1(IEnumerable<string> input)
    {
        var allDigits = new List<int>();
        foreach (var row in input)
        {
            var number = string.Empty;
            // first digit
            for (int i = 0; i < row.Length; i++)
            {
                if (int.TryParse(row[i].ToString(), out _))
                {
                    number += row[i];
                    break;
                }
            }
            // find second digit
            for (int i = row.Length - 1; i >= 0; i--)
            {
                if (int.TryParse(row[i].ToString(), out _))
                {
                    number += row[i];
                    break;
                }
            }
            // add do big list
            allDigits.Add(int.Parse(number));
        }
        return allDigits.Sum();
    }

    public static int GetSolutionPart2(IEnumerable<string> input) => 1;
}