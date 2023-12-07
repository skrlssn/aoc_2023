namespace aoc;

public static class Puzzle
{
    private static List<FarmerMap> GetFarmerMapList(IEnumerable<string> input, int startIndex, int stopIndex)
    {
        var returnList = new List<FarmerMap>();
        for (int i = startIndex; i < stopIndex; i++)
        {
            var values = input.ElementAt(i).Split(" ");
            returnList.Add(new FarmerMap(long.Parse(values[0]), long.Parse(values[1]), long.Parse(values[2])));
        }
        return returnList;
    }

    private static long GetNewSource(List<FarmerMap> list, long oldSource)
    {
        var row = list.FirstOrDefault(x => x.Source <= oldSource && x.Source + x.Range >= oldSource);
        return row == null ? oldSource : row.Destination + (oldSource - row.Source);
    }

    public static long GetSolutionPart1(IEnumerable<string> input)
    {
        var seed2soils = GetFarmerMapList(input, 3, 15);
        var soil2ferts = GetFarmerMapList(input, 17, 46);
        var ferts2water = GetFarmerMapList(input, 48, 65);
        var water2light = GetFarmerMapList(input, 67, 85);
        var light2temp = GetFarmerMapList(input, 87, 121);
        var temp2hum = GetFarmerMapList(input, 123, 158);
        var hum2loc = GetFarmerMapList(input, 160, 172);

        var seeds = input.First().Split("seeds: ")[1].Split(" ").Select(long.Parse);
        var locs = new List<long>();

        foreach (var seed in seeds)
        {
            var soilSource = GetNewSource(seed2soils, seed);
            var fertSource = GetNewSource(soil2ferts, soilSource);
            var waterSource = GetNewSource(ferts2water, fertSource);
            var lightSource = GetNewSource(water2light, waterSource);
            var tempSource = GetNewSource(light2temp, lightSource);
            var humSource = GetNewSource(temp2hum, tempSource);
            var locSource = GetNewSource(hum2loc, humSource);

            locs.Add(locSource);
        }

        return locs.Min();
    }

    public static int GetSolutionPart2(IEnumerable<string> input)
    {
        return -1;
    }
}

public class FarmerMap
{
    public long Destination { get; set; }
    public long Source { get; set; }
    public long Range { get; set; }
    public FarmerMap(long destination, long source, long range)
    {
        Destination = destination;
        Source = source;
        Range = range;
    }
}