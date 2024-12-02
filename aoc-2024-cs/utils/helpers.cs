namespace aoc_2024_cs.utils;

internal static class Helpers
{
    public static string[] GetLines(string relPath)
    {
        var srcDir = (Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName);
        return File.ReadAllLines(Path.Join(srcDir, relPath));
    }
}