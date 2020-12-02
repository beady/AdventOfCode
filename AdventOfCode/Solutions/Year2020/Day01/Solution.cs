using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day01 : ASolution
    {

        public Day01() : base(01, 2020, "")
        {
//            DebugInput = @"1721
//979
//366
//299
//675
//1456";
        }

        protected override string SolvePartOne()
        {
            var values = Input.SplitByNewline().Select(x => int.Parse(x)).ToList();
            var length = values.Count;

            for (int index1 = 0; index1 < values.Count; index1++)
            {
                for (int index2 = index1 + 1; index2 < values.Count; index2++)
                {
                    if (values[index1] + values[index2] == 2020)
                    {
                        var result = (values[index1] * values[index2]);
                        return (values[index1] * values[index2]).ToString();
                    }
                }
            }

            throw new InvalidOperationException();
        }

        protected override string SolvePartTwo()
        {
            var values = Input.SplitByNewline().Select(x => int.Parse(x)).ToList();
            var length = values.Count;

            for (int index1 = 0; index1 < values.Count; index1++)
            {
                for (int index2 = index1 + 1; index2 < values.Count; index2++)
                {
                    for (int index3 = index2 + 1; index3 < values.Count; index3++)
                    {
                        if (values[index1] + values[index2] + values[index3] == 2020)
                        {
                            var result = (values[index1] * values[index2] * values[index3]);
                            return result.ToString();
                        }
                    }
                }
            }
            throw new InvalidOperationException();
        }
    }
}
