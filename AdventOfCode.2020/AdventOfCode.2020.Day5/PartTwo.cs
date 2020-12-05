using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode._2020.Day5
{
  [TestFixture]
  public class PartTwo
  {
    [Test]
    public void Find_Seat_Id()
    {
      var ids = File.ReadAllLines("input.txt").Select(s => s.ToSeatId()).ToHashSet();
      var seatId = ids.Single(id => !ids.Contains(id + 1) && ids.Contains(id + 2)) + 1;
      seatId.Should().Be(517);
    }
  }
}
