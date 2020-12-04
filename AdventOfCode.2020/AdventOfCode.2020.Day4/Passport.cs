using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day4
{
  public class Passport
  {
    public Dictionary<string, string> Fields { get; }

    public Passport(IEnumerable<string> fieldLines)
    {
      Fields = new Dictionary<string, string>();
      foreach (var line in fieldLines)
        line.Split(" ").ToList().ForEach(x => Fields.Add(x.Split(":")[0], x.Split(":")[1]));
    }

    public bool IsValid() => !Fields.ContainsKey("cid") ? Fields.Count == 7 : Fields.Count == 8;
    public bool IsValidStrict() => IsValid() && Fields.All(x => ValidationRules[x.Key](x.Value));

    private static readonly Dictionary<string, Func<string, bool>> ValidationRules = new Dictionary<string, Func<string, bool>>()
    {
      {"byr", IsValidBirthYear},
      {"iyr", IsValidIssueYear},
      {"eyr", IsValidExpirationYear},
      {"hgt", IsValidHeight},
      {"hcl", IsValidHairColor},
      {"ecl", IsValidEyeColor},
      {"pid", IsValidPassportId},
      {"cid", s => true }
    };

    private static bool IsValidBirthYear(string s) => s.Count() == 4 && int.Parse(s) >= 1920 && int.Parse(s) <= 2020;
    private static bool IsValidIssueYear(string s) => s.Count() == 4 && int.Parse(s) >= 2010 && int.Parse(s) <= 2020;
    private static bool IsValidExpirationYear(string s) => s.Count() == 4 && int.Parse(s) >= 2020 && int.Parse(s) <= 2030;

    private static bool IsValidHeight(string s)
    {
      if (s.Contains("cm"))
      {
        var value = int.Parse(s.Split("cm")[0]);
        return value >= 150 && value <= 193;
      }

      if (s.Contains("in"))
      {
        var value = int.Parse(s.Split("in")[0]);
        return value >= 59 && value <= 76;
      }

      return false;
    }

    private static bool IsValidHairColor(string s)
    {
      return s.Length >= 1 && s.First() == '#' && s.Length == 7 &&
             s.Skip(1).All(c => "qwertyuiopasdfghjklzxcvbnm1234567890".Contains(c));
    }

    private static bool IsValidEyeColor(string s) => new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(s);
    private static bool IsValidPassportId(string s) => s.Length == 9 && long.TryParse(s, out _);
  }
}
