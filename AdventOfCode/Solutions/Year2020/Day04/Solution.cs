using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day04 : ASolution
    {

        string part2InvalidPassports = @"eyr:1972 cid:100
hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926

iyr:2019
hcl:#602927 eyr:1967 hgt:170cm
ecl:grn pid:012533040 byr:1946

hcl:dab227 iyr:2012
ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277

hgt:59cm ecl:zzz
eyr:2038 hcl:74454a iyr:2023
pid:3556412378 byr:2007";

        string part2ValidPassports = @"pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980
hcl:#623a2f

eyr:2029 ecl:blu cid:129 byr:1989
iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm

hcl:#888785
hgt:164cm byr:2001 iyr:2015 cid:88
pid:545766238 ecl:hzl
eyr:2022

iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719";



        public Day04() : base(04, 2020, "")
        {
            //DebugInput = part2ValidPassports;
        }

        protected override string SolvePartOne()
        {
            int validItems = 0;
            foreach(var item in Input.Split(Environment.NewLine + Environment.NewLine))
            {
                var passport = new Passport(item);
                if (passport.ValidatePart1())
                    validItems++;
             }

            return validItems.ToString();
        }

        protected override string SolvePartTwo()
        {
            int validItems = 0;
            foreach (var item in Input.Split(Environment.NewLine + Environment.NewLine))
            {
                var passport = new Passport(item);
                if (passport.ValidatePart2())
                    validItems++;
            }

            return validItems.ToString();
        }

        protected class Passport
        {
            public Dictionary<string, string> Parts = new Dictionary<string, string>();
            public Passport(string passportText)
            {
                foreach (var line in passportText.Split(Environment.NewLine))
                {
                    foreach (var token in line.Split(" "))
                    {
                        var parts = token.Split(":");
                        Parts.Add(parts[0], parts[1]);
                    }
                }
            }

            public bool ValidatePart1() {
                return Parts.ContainsKey("byr") && Parts.ContainsKey("iyr") && Parts.ContainsKey("eyr") && Parts.ContainsKey("hgt") && Parts.ContainsKey("hcl") && Parts.ContainsKey("ecl") && Parts.ContainsKey("pid");
            }

            public bool ValidateYear(string value, int minAllowed, int maxAllowed) {

                if (value.Length != 4)
                    return false;

                if (!int.TryParse(value, out int year))
                    return false;

                if (year < minAllowed || year > maxAllowed)
                    return false;

                return true;
            }


            public bool ValidatePart2()
            {
                if (!(Parts.ContainsKey("byr") && Parts.ContainsKey("iyr") && Parts.ContainsKey("eyr") && Parts.ContainsKey("hgt") && Parts.ContainsKey("hcl") && Parts.ContainsKey("ecl") && Parts.ContainsKey("pid"))) {
                    return false;
                }

                if (!ValidateYear(Parts["byr"], 1920, 2002))
                    return false;

                if (!ValidateYear(Parts["iyr"], 2010, 2020))
                    return false;

                if (!ValidateYear(Parts["eyr"], 2020, 2030))
                    return false;


                var heightType = Parts["hgt"].Substring(Parts["hgt"].Length - 2, 2);
                var heightValue = Parts["hgt"].Substring(0, Parts["hgt"].Length - 2);

                if (heightType != "cm" && heightType != "in")
                    return false;
                
                if (!int.TryParse(heightValue, out int heightint))
                    return false;

                if (heightType == "cm") 
                    if (heightint < 150 || heightint > 193)
                        return false;
                
                if (heightType == "in")
                    if (heightint < 59 || heightint > 76)
                        return false;

                var hairColour = Parts["hcl"];
                if (!hairColour.StartsWith("#"))
                    return false;

                var chars = 0;
                var validChars = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' ,'0', 'a', 'b', 'c', 'd', 'e', 'f' };
                foreach(var hcc in hairColour[1..].ToCharArray()) {
                    if (!validChars.Contains(hcc))
                        return false;
                    chars++;
                }

                if (chars != 6)
                    return false;

                var validEyeColours = new List<string>{"amb","blu","brn","gry","grn","hzl","oth" };

                if (!validEyeColours.Contains(Parts["ecl"]))
                    return false;

                var passportId = Parts["pid"];
                if (passportId.Length != 9)
                    return false;

                if (!int.TryParse(passportId, out int passportNumber))
                    return false;


                return true;
            }
        }
    }
}
