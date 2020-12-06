using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode._2020.Day6
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    public void Counts_Sum_Of_Yes_Answers_In_Example()
    {
      "example.txt"
        .ReadGroups()
        .ToSumOfAnyYesAnswer()
        .Should()
        .Be(11);
    }

    [Test]
    public void Counts_Sum_Of_Yes_Answers()
    {
      "input.txt"
        .ReadGroups()
        .ToSumOfAnyYesAnswer()
        .Should()
        .Be(6297);
    }
  }
}
