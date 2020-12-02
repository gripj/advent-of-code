using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode._2020.Day1
{
  [TestFixture]
  public class PartTwo
  {
    [Test]
    public void Calculator_Finds_Sum_In_Example()
    {
      var entriesInExample = new int[]
      {
        1721,
        979,
        366,
        299,
        675,
        1456,
      };

      var answer = ExpenseReportCalculator.CalculateForThreeEntries(entriesInExample);

      answer.Should().Be(241861950);
    }

    [Test]
    public void Calculator_Finds_Sum()
    {
      var entries = File.ReadAllLines("input.txt").Select(int.Parse).ToArray();

      var answer = ExpenseReportCalculator.CalculateForThreeEntries(entries);

      answer.Should().Be(286977330);
    }
  }
}
