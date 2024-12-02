using aoc_2024_cs.utils;

namespace aoc_2024_cs.d1;

public static class D1
{
    public static void P1()
    {
        var lines = Helpers.GetLines("/d1/p1.txt");
        var lNums = new List<int>();
        var rNums = new List<int>();
        foreach (var line in lines)
        {
            var nums = line.Split("   ");
            lNums.Add(int.Parse(nums[0]));
            rNums.Add(int.Parse(nums[1]));
        }

        lNums.Sort();
        rNums.Sort();
        var diff = lNums.Select((val, i) => int.Abs(val - rNums[i])).Sum();
        Console.WriteLine("{0}", diff);
    }

    public static void P2()
    {
        var lines = Helpers.GetLines("/d1/p2.txt");
        var lNums = new List<int>();
        var mults = new Dictionary<int, int>();
        foreach (var line in lines)
        {
            var nums = line.Split("   ");
            lNums.Add(int.Parse(nums[0]));
            var rNum = int.Parse(nums[1]);

            if (!mults.TryAdd(rNum, 1)) mults[rNum]++;
        }

        var score = lNums.Aggregate(0, (acc, val) => acc + val * mults.GetValueOrDefault(val, 0));

        Console.WriteLine("{0}", score);
    }
}