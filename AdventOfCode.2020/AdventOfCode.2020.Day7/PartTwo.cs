using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode._2020.Day7
{
  [TestFixture]
  public class PartTwo
  {
    [Test]
    public void Counts_Individual_Bags_Required_In_Example()
    {
      var bagRules = new[]
      {
        "shiny gold bags contain 2 dark red bags.",
        "dark red bags contain 2 dark orange bags.",
        "dark orange bags contain 2 dark yellow bags.",
        "dark yellow bags contain 2 dark green bags.",
        "dark green bags contain 2 dark blue bags.",
        "dark blue bags contain 2 dark violet bags.",
        "dark violet bags contain no other bags."
      };
      bagRules.ParseBags()["shiny gold"].CountBags().Should().Be(126);
    }

    [Test]
    public void Counts_Individual_Bags_Required()
    {
      "input.txt".ParseBags()["shiny gold"].CountBags().Should().Be(9569);
    }
  }
}
