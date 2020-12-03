using System;

namespace AdventOfCode._2020.Day3
{
  public class Map
  {
    private readonly string[] _lines;
    private int Height => _lines.Length;
    private int Width => _lines[0].Length;

    public Map(string[] lines)
    {
      _lines = lines ?? throw new InvalidOperationException(nameof(lines));
    }

    public long CountTrees(int right, int down)
    {
      var trees = 0;

      var x = 0;
      for (var y = 0; y < Height; y += down)
      {
        if (_lines[y][x] == '#')
          trees += 1;

        x += right;
        x %= Width;
      }

      return trees;
    }
  }
}
