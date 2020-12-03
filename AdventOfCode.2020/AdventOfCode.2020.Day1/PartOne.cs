using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode._2020.Day1
{
  [TestFixture]
  public class PartOne
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

      var answer = ExpenseReportCalculator.Calculate(entriesInExample);

      answer.Should().Be(514579);
    }

    [Test]
    public void FileReader_Reads_Input()
    {
      File.ReadAllLines("input.txt").Length.Should().Be(200);
    }

    [Test]
    public void Calculator_Finds_Sum()
    {
      var entries = File.ReadAllLines("input.txt").Select(int.Parse).ToArray();

      var answer = ExpenseReportCalculator.Calculate(entries);

      answer.Should().Be(1020036);
    }
  }
}
