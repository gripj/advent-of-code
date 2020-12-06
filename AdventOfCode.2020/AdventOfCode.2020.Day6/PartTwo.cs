using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode._2020.Day6
{
  [TestFixture]
  public class PartTwo
  {
    [Test]
    public void Counts_Sum_Of_Yes_Answers_In_Example()
    {
      "example.txt"
        .ReadGroups()
        .ToSumOfEveryYesAnswer()
        .Should()
        .Be(6);
    }

    [Test]
    public void Counts_Sum_Of_Yes_Answers()
    {
      "input.txt"
        .ReadGroups()
        .ToSumOfEveryYesAnswer()
        .Should()
        .Be(3158);
    }
  }
}
