using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day02 : ASolution
    {

        public Day02() : base(02, 2020, "")
        {
//            DebugInput = @"1-3 a: abcde
//1-3 b: cdefg
//2-9 c: ccccccccc";
        }

        protected override string SolvePartOne()
        {
            var values = Input.SplitByNewline();

            var validCount = 0;

            foreach (var item in values)
            {
                var parts = item.Split(":");
                var policyParts = parts[0].Split(" ");
                var counts = policyParts[0].Split("-");
                var policy = new PasswordPolicy(int.Parse(counts[0]), int.Parse(counts[1]), policyParts[1].FirstOrDefault());

                var validPasswordChars = parts[1].Where(x => x.Equals(policy.letter)).ToArray();
                if (validPasswordChars.Length >= policy.Min && validPasswordChars.Length <= policy.Max)
                {
                    validCount++;
                }
            }

            return validCount.ToString();
        }

        protected override string SolvePartTwo()
        {
            var values = Input.SplitByNewline();

            var validCount = 0;

            foreach (var item in values)
            {
                var parts = item.Split(":");
                var policyParts = parts[0].Split(" ");
                var counts = policyParts[0].Split("-");
                var policy = new PasswordPolicy(int.Parse(counts[0]), int.Parse(counts[1]), policyParts[1].FirstOrDefault());

                var password = parts[1];

                if ((password[policy.Min] == policy.letter) ^ (password[policy.Max] == policy.letter))
                {
                    validCount++;
                }
            }

            return validCount.ToString();
        }

        private record PasswordPolicy(int Min, int Max, char letter) { };
    }
}
