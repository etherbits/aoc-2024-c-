using aoc_2024_cs.utils;

namespace aoc_2024_cs.d2;

public static class D2
{
    public static void P1()
    {
        var lines = Helpers.GetLines("/d2/p1.txt");
        var goodCount = lines.Sum(line => IsGood(line) ? 1 : 0);

        Console.WriteLine(goodCount);
    }

    public static void P2()
    {
        var lines = Helpers.GetLines("/d2/p2.txt");
        var goodCount = lines.Sum(line => IsGoodTol(line) ? 1 : 0);

        Console.WriteLine(goodCount);
    }

    private static bool IsGood(string line)
    {
        var nums = line.Split(" ").Select(int.Parse).ToList();
        var dir = nums[1] - nums[0] > 0 ? 1 : -1;

        for (var i = 0; i < nums.Count - 1; i++)
        {
            var change = nums[i + 1] - nums[i];
            if (IsBadChange(change, dir)) return false;
        }

        return true;
    }

    private static bool IsGoodTol(string line)
    {
        var nums = line.Split(" ").Select(int.Parse).ToList();
        var numPerms = nums.Select((num, i) =>
        {
            var newNums = new List<int>(nums);
            newNums.RemoveAt(i);
            return newNums;
        }).ToList();
        numPerms.Add(nums);

        return numPerms.Any(numPerm =>
        {
            var dir = numPerm[1] - numPerm[0] > 0 ? 1 : -1;
            for (var i = 0; i < numPerm.Count - 1; i++)
            {
                var change = numPerm[i + 1] - numPerm[i];

                if (IsBadChange(change, dir)) return false;
            }

            return true;
        });
    }

    private static bool IsBadChange(int change, int dir)
    {
        return change * dir <= 0 || Math.Abs(change) < 1 || Math.Abs(change) > 3;
    }
}