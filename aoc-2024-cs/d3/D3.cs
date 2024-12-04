using System.Text.RegularExpressions;
using aoc_2024_cs.utils;

namespace aoc_2024_cs.d3;

public static class D3
{
    public static void P1()
    {
        var lines = Helpers.GetLines("/d3/p1.txt");
        var text = string.Join("\n", lines);

        var val = GetInstVal(text);

        Console.WriteLine(val);
    }

    public static void P2()
    {
        var lines = Helpers.GetLines("/d3/p2.txt");
        var text = string.Join("\n", lines);

        const string enabledPattern = @"(?:^|do\(\))((?:(?!don't\(\))[\S\s])+)(?:$|don't\(\))";
        var matches = Regex.Matches(text, enabledPattern);

        var val = matches.Aggregate(0, (acc, match) => acc + GetInstVal(match.Groups[1].Value));

        Console.WriteLine(val);
    }

    private static int GetInstVal(string text)
    {
        const string instPattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        var matches = Regex.Matches(text, instPattern);

        var val = matches.Aggregate(0, (acc, match) =>
        {
            var n1 = int.Parse(match.Groups[1].Value);
            var n2 = int.Parse(match.Groups[2].Value);
            return acc + n1 * n2;
        });
        return val;
    }
}