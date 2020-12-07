using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._2020.Day7
{
  public class Bag
  {
    public string Color { get; set; }
    public IList<(Bag bag, int amount)> Children { get; set; } = new List<(Bag, int)>();
    public IList<Bag> Parents { get; set; } = new List<Bag>();

    public HashSet<string> ParentColors => Parents.SelectMany(p => p.ParentColors.Concat(new[] { p.Color })).ToHashSet();

    public long CountBags() => Children.Sum(c => c.amount) + Children.Sum(c => c.bag.CountBags() * c.amount);
  }

  public static class BagExtensions
  {
    public static Dictionary<string, Bag> ParseBags(this string[] rules)
    {
      var bags = new Dictionary<string, Bag>();

      foreach (var line in rules)
      {
        var parts = line.Split("bags contain");
        var (color, contains) = (parts[0].Trim(), parts[1].Split(",").Select(x => x.Trim()));

        var bag = bags.GetValueOrDefault(color) ?? new Bag { Color = color };
        if (!bags.ContainsKey(color))
          bags[color] = bag;

        foreach (var contained in contains)
        {
          if (contained == "no other bags.")
            continue;

          var amountString = contained.Split()[0];
          var containedColor = contained.Replace(amountString, "").Split("bag")[0].Trim();

          var otherBag = bags.GetValueOrDefault(containedColor) ?? new Bag { Color = containedColor };
          if (!bags.ContainsKey(containedColor))
            bags[containedColor] = otherBag;

          otherBag.Parents.Add(bag);
          bag.Children.Add((otherBag, int.Parse(amountString)));
        }
      }

      return bags;
    }

    public static Dictionary<string, Bag> ParseBags(this string inputFileName) => File.ReadAllLines(inputFileName).ParseBags();
  }
}
