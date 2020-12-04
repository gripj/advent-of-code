using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode._2020.Day4
{
  [TestFixture]
  public class PartOne
  {
    [Test]
    public void Passport_Should_Parse_From_FieldLines()
    {
      var fieldLines = new List<string>()
      {
        "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
        "byr:1937 iyr:2017 cid:147 hgt:183cm"
      };

      var passport = new Passport(fieldLines);

      passport.Fields["ecl"].Should().Be("gry");
      passport.Fields["pid"].Should().Be("860033327");
      passport.Fields["eyr"].Should().Be("2020");
      passport.Fields["hcl"].Should().Be("#fffffd");
      passport.Fields["byr"].Should().Be("1937");
      passport.Fields["iyr"].Should().Be("2017");
      passport.Fields["cid"].Should().Be("147");
      passport.Fields["hgt"].Should().Be("183cm");
    }

    [Test]
    public void Passport_With_All_Fields_Are_Valid()
    {
      var allFieldLines = new List<string>()
      {
        "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
        "byr:1937 iyr:2017 cid:147 hgt:183cm"
      };

      new Passport(allFieldLines).IsValid().Should().BeTrue();
    }

    [Test]
    public void Passport_With_Missing_Fields_Should_Be_Invalid()
    {
      var allFieldLines = new List<string>()
      {
        "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884",
        "hcl:#cfa07d byr:1929"
      };

      new Passport(allFieldLines).IsValid().Should().BeFalse();
    }

    [Test]
    public void Passport_With_Cid_As_Only_Missing_Field_Should_Be_Valid()
    {
      var allFieldLines = new List<string>()
      {
        "hcl:#ae17e1 iyr:2013",
        "eyr:2024",
        "ecl:brn pid:760753108 byr:1931",
        "hgt:179cm"
      };

      new Passport(allFieldLines).IsValid().Should().BeTrue();
    }

    [Test]
    public void Counts_Number_Of_Valid_Passports()
    {
      PassportReader.Read().Count(x => x.IsValid()).Should().Be(213);
    }
  }
}
