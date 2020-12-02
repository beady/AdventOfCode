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
            //DebugInput = @"1721
            //979
            //366
            //299
            //675
            //1456";
        }

        protected string SolvePartOneOld()
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


        protected override string SolvePartOne()
        {
            var values = Input.SplitByNewline().Select(x => int.Parse(x)).ToArray();

            foreach (var item in GetCombinations(values, 2))
            {
                if (item[0] + item[1] == 2020)
                {
                    var result = (item[0] * item[1]);
                    return result.ToString();
                }
            }
            throw new InvalidOperationException();
        }

        protected string SolvePartTwoOld()
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

        protected override string SolvePartTwo()
        {
            var values = Input.SplitByNewline().Select(x => int.Parse(x)).ToArray();

            foreach (var item in GetCombinations(values, 3))
            {
                if (item[0] + item[1] + item[2] == 2020)
                {
                    var result = (item[0] * item[1] * item[2]);
                    return result.ToString();
                }
            }
            throw new InvalidOperationException();
        }


        protected IEnumerable<T[]> GetCombinations<T>(T[] items, int count)
        {
            int[] index = new int[count];
            int[] maxIndex = new int[count];

            for (int initial = 0; initial < count; initial++)
            {
                index[initial] = initial;
                maxIndex[initial] = items.Length - count + initial;
            }

            var carryOn = true;
            while (carryOn)
            {
                yield return outputCurrentIndexes();
                carryOn = IncrementIndexes();
            }

            yield break;

            bool IncrementIndexes()
            {
                for (int checkIndex = count - 1; checkIndex >= 0; checkIndex--)
                {
                    if (index[checkIndex] < maxIndex[checkIndex])
                    {
                        index[checkIndex]++;
                        for (int resetIndexOffset = 1; resetIndexOffset < count - checkIndex; resetIndexOffset++)
                        {
                            index[checkIndex + resetIndexOffset] = index[checkIndex] + resetIndexOffset;
                        }  
                        return true;
                    }
                }

                return false;
            }

            T[] outputCurrentIndexes()
            {
                var values = new T[count];
                for (int current = 0; current < count; current++)
                {
                    values[current] = items[index[current]];
                }
                return values;
            }

        }
    }
}
