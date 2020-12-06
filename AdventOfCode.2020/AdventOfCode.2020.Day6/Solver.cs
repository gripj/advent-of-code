using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using static System.Environment;
using static System.Char;

namespace AdventOfCode._2020.Day6
{
  public static class Solver
  {
    public static IEnumerable<string> ReadGroups(this string s) => File.ReadAllText(s).Split(NewLine + NewLine);

    public static int ToSumOfAnyYesAnswer(this IEnumerable<string> groups) =>
      groups.Select(group => group.Where(IsLetter).ToImmutableHashSet().Count()).Sum();

    public static int ToSumOfEveryYesAnswer(this IEnumerable<string> groups) =>
      groups.Sum(
        grp => grp.Split(NewLine)
          .Select(line => line.ToHashSet())
          .Aggregate((lineA, lineB) => lineA.Intersect(lineB).ToHashSet())
          .Count
      );
  }
}
