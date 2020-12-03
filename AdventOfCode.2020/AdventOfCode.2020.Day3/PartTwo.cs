using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode._2020.Day3
{
  [TestFixture]
  public class PartTwo
  {
    private readonly (int x, int y)[] _slopes = { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };

    [Test]
    public void Multiplies_Trees_Encountered_In_Slopes_For_Example()
    {
      var map = new Map(new[]
      {
        "..##.......",
        "#...#...#..",
        ".#....#..#.",
        "..#.#...#.#",
        ".#...##..#.",
        "..#.##.....",
        ".#.#.#....#",
        ".#........#",
        "#.##...#...",
        "#...##....#",
        ".#..#...#.#"
      });

      _slopes
        .Aggregate(1L, (acc, slope) => acc *= map.CountTrees(slope.x, slope.y))
        .Should().Be(336);
    }

    [Test]
    public void Multiplies_Trees_Encountered_In_Slopes()
    {
      var map = new Map(File.ReadAllLines("input.txt"));

      _slopes
        .Aggregate(1L, (acc, slope) => acc *= map.CountTrees(slope.x, slope.y))
        .Should().Be(7812180000);
    }
  }
}
