using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode._2020.Day2
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    [TestCase("1-3 a: abcde", true)]
    [TestCase("1-3 b: cdefg", false)]
    [TestCase("2-9 c: ccccccccc", true)]
    public void PasswordValidator_Validates_Passwords_In_Example(string passwordLine, bool isValid)
    {
      PasswordValidator.IsValid(passwordLine).Should().Be(isValid);
    }

    [Test]
    public void Calculates_Number_Of_Valid_Passwords_In_Input()
    {
      var numberOfValidPasswords = File.ReadLines("input.txt").Select(x => PasswordValidator.IsValid(x)).Count(x => x);
      numberOfValidPasswords.Should().Be(410);
    }
  }
}
