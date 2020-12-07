using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode._2020.Day7
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    public void Counts_Number_Of_Bag_Colors_That_Can_Contain_At_Least_On_Shiny_Bag_In_Example()
    {
      var bagRules = new []
      {
        "light red bags contain 1 bright white bag, 2 muted yellow bags.",
        "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
        "bright white bags contain 1 shiny gold bag.",
        "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
        "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
        "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
        "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
        "faded blue bags contain no other bags.",
        "dotted black bags contain no other bags."
      };
      bagRules.ParseBags()["shiny gold"].ParentColors.Count.Should().Be(4);
    }

    [Test]
    public void Counts_Number_Of_Bag_Colors_That_Can_Contain_At_Least_On_Shiny_Bag()
    {
      "input.txt".ParseBags()["shiny gold"].ParentColors.Count.Should().Be(226);
    }
  }
}
