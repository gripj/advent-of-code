using System.Linq;

namespace AdventOfCode._2020.Day5
{
  public static class SeatIdExtensions
  {
    public static int ToSeatId(this string s) => s.Aggregate(0, (i, c) => 2 * i + (c.IsBackOrRight() ? 1 : 0));
    private static bool IsBackOrRight(this char c) => c % 8 == 2;
  }
}
