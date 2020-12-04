using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode._2020.Day4
{
  public static class PassportReader
  {
    public static IEnumerable<Passport> Read()
    {
      var lines = File.ReadAllLines("input.txt");

      var fieldLines = new List<string>();
      foreach (var line in lines)
      {
        if (!string.IsNullOrWhiteSpace(line))
          fieldLines.Add(line);
        else
        {
          yield return new Passport(fieldLines);
          fieldLines = new List<string>();
        }
      }
      yield return new Passport(fieldLines);
    }
  }
}
