using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode._2020.Day3
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    public void Map_Counts_Trees_In_Example()
    {
      new Map(new[]
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
        }).CountTrees(3, 1).Should().Be(7);
    }

    [Test]
    public void Map_Counts_Trees_In_Input()
    {
      new Map(File.ReadAllLines("input.txt")).CountTrees(3, 1).Should().Be(276);
    }
  }
}
