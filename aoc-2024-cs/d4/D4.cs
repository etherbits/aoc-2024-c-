using aoc_2024_cs.utils;

namespace aoc_2024_cs.d4;

public static class D4
{
    private static readonly List<(int, int)> dirs =
        [(-1, -1), (0, -1), (1, -1), (-1, 0), (1, 0), (-1, 1), (0, 1), (1, 1)];

    public static void P1()
    {
        var lines = Helpers.GetLines("/d4/p1.txt");
        var charMatrix = lines.Select(line => line.ToCharArray()).ToList();
        var visited = new bool[charMatrix.Count, charMatrix[0].Length];

        var count = charMatrix
            .Select((chars, r) =>
                chars.Select((_, c) => dirs.Select(dir => RecFind("", "XMAS", (r, c), dir, visited, charMatrix)).Sum())
                    .Sum())
            .Sum();

        Console.WriteLine(count);
    }

    public static void P2()
    {
        var lines = Helpers.GetLines("/d4/p2.txt");
        var charMatrix = lines.Select(line => line.ToCharArray()).ToList();

        var fullDirs = new List<(int, int)>(dirs);
        fullDirs.Insert(4, (0, 0));

        List<(int, int)>[] dirSecs =
        [
            fullDirs.GetRange(0, 3),
            fullDirs.GetRange(3, 3),
            fullDirs.GetRange(6, 3)
        ];

        var count = 0;
        for (var i = 1; i < charMatrix.Count - 1; i++)
        for (var j = 1; j < charMatrix.Count - 1; j++)
        {
            if (charMatrix[i][j] != 'A') continue;
            var crossChars =
                dirSecs.Select(dirSec => dirSec.Select(dir => charMatrix[i + dir.Item1][j + dir.Item2]).ToList())
                    .ToList();

            count += Convert.ToInt16(CrossCompare(crossChars, "MAS"));
        }

        Console.WriteLine(count);
    }

    private static int RecFind(string word, string target, (int, int) coord, (int, int) dir, bool[,] vis,
        List<char[]> matrix)
    {
        var visited = (bool[,])vis.Clone();
        var (r, c) = coord;

        if (r < 0 || r >= matrix.Count || c < 0 || c >= matrix[0].Length || word.Length >= target.Length ||
            visited[r, c]) return 0;

        visited[r, c] = true;
        word += matrix[r][c];

        if (word == target) return 1;
        if (!target.StartsWith(word)) return 0;

        return RecFind(word, target, (r + dir.Item1, c + dir.Item2), dir, visited, matrix);
    }

    private static bool CrossCompare(List<List<char>> charMatrix, string target)
    {
        string[] diags = ["", ""];

        for (var i = 0; i < charMatrix.Count; i++)
        {
            diags[0] += charMatrix[i][i];
            diags[1] += charMatrix[i][charMatrix.Count - 1 - i];
        }

        var allValid = diags.ToList().All(diag => diag == target || diag == new string(target.Reverse().ToArray()));

        return allValid;
    }
}