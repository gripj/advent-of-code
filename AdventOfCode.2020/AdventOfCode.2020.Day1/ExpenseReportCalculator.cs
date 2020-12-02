using System.Collections.Generic;

namespace AdventOfCode._2020.Day1
{
  public static class ExpenseReportCalculator
  {
    public static int Calculate(int[] entries)
    {
      var (first, second) = entries.FindTwoNumbersWithSum();
      return first * second;
    }

    public static int CalculateForThreeEntries(int[] entries)
    {
      for (var i = 0; i < entries.Length - 2; i++)
      {
        var currentSum = 2020 - entries[i];

        var (first, second) = entries.FindTwoNumbersWithSum(currentSum);
        if (first != 0)
          return entries[i] * first * second;
      }

      return 0;
    }

    private static (int first, int second) FindTwoNumbersWithSum(this IEnumerable<int> entries, int sum = 2020)
    {
      var hashTable = new HashSet<int>();

      foreach (var entry in entries)
      {
        if (hashTable.Contains(sum - entry))
          return ((entry, (sum - entry)));

        hashTable.Add(entry);
      }

      return (0, 0);
    }
  }
}
