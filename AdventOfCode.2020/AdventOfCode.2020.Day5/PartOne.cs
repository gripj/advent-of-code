using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode._2020.Day5
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    public void ToSeatId_Calculates_SeatId_In_Example()
    {
      "FBFBBFFRLR".ToSeatId().Should().Be(357);
    }

    [Test]
    public void Find_Highest_SeatId()
    {
      var ids = File.ReadAllLines("input.txt").Select(s => s.ToSeatId()).ToHashSet();
      ids.Max().Should().Be(832);
    }
  }
}
