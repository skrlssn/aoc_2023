namespace aoc;

public static class Puzzle
{
    public static long GetSolutionPart1(IEnumerable<string> input)
    {
        var times = input.First().Split().Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).Where(x => x != "Time:").Select(int.Parse);
        var distances = input.Last().Split().Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).Where(x => x != "Distance:").Select(int.Parse);

        var winningsInEachRays = new List<int>();

        for (int i = 0; i < times.Count(); i++)
        {
            winningsInEachRays.Add(GetWinningWays(times.ElementAt(i), distances.ElementAt(i)));
        }

        return winningsInEachRays.Aggregate((x, y) => x * y);
    }

    public static int GetSolutionPart2(IEnumerable<string> input)
    {
        var time = long.Parse(input.First().Split("Time:").ElementAt(1).Replace(" ", ""));
        var distance = long.Parse(input.Last().Split("Distance:").ElementAt(1).Replace(" ", ""));

        return GetWinningWays(time, distance);
    }

    private static int GetWinningWays(long maxTime, long minDistance)
    {
        var winningWays = 0;
        bool startedWinning = false;
        for (int j = 0; j < maxTime; j++)
        {
            var hold = j;
            var distance = (maxTime - hold) * hold;
            if (distance > minDistance)
            {
                startedWinning = true;
                winningWays++;
            }
            else if (startedWinning)
            {
                return winningWays;
            }
        }
        return 0;
    }
}
