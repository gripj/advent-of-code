using System.Linq;

namespace AdventOfCode._2020.Day2
{
  public static class PasswordValidator
  {
    public static bool IsValid(string line, PasswordPolicy policy = PasswordPolicy.Old)
    {
      var parts = line.Split(" ");
      var (a, b, letter, password) = (int.Parse(parts[0].Split("-")[0]), int.Parse(parts[0].Split("-")[1]), parts[1][0], parts[2]);

      if (policy == PasswordPolicy.Old)
      {
        var letterCount = password.Count(l => l == letter);
        return letterCount >= a && letterCount <= b;
      }

      return (password[a - 1] == letter || password[b - 1] == letter) && !(password[a - 1] == letter && password[b - 1] == letter);
    }
  }

  public enum PasswordPolicy
  {
    Old,
    TobogganCorporate
  }
}
