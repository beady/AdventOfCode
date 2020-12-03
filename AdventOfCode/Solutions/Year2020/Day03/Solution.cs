using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day03 : ASolution
    {

        public Day03() : base(03, 2020, "")
        {
            var exampleInput = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";

            //DebugInput = exampleInput;

        }

        protected override string SolvePartOne()
        {
            var partialMap = Input.SplitByNewline();
            var patialMapWidth = partialMap[0].Length;

            var xPos = 0;
            var yPos = 0;

            var xInc = 3;
            var yInc = 1;

            var trees = 0;

            while (yPos < partialMap.Length)
            {
                if (partialMap[yPos][xPos] == '#')
                {
                    trees++;
                }

                xPos = (xPos + xInc) % patialMapWidth;
                yPos += yInc;
            }

            return trees.ToString();

        }

        protected override string SolvePartTwo()
        {
            var partialMap = Input.SplitByNewline();

            var trees11 = SolveMap(partialMap, 1, 1);
            var trees31 = SolveMap(partialMap, 3, 1);
            var trees51 = SolveMap(partialMap, 5, 1);
            var trees71 = SolveMap(partialMap, 7, 1);
            var trees12 = SolveMap(partialMap, 1, 2);

            Console.WriteLine($"{trees11}, {trees31}, {trees51}, {trees71}, {trees12}");

            return (trees11 * trees31 * trees51 * trees71 * trees12).ToString();

        }

        protected long SolveMap(string[] partialMap, int xInc, int yInc)
        {
            //var partialMap = Input.SplitByNewline();
            var patialMapWidth = partialMap[0].Length;

            var xPos = 0;
            var yPos = 0;

            long trees = 0;

            while (yPos < partialMap.Length)
            {
                if (partialMap[yPos][xPos] == '#')
                {
                    trees++;
                }

                xPos = (xPos + xInc) % patialMapWidth;
                yPos += yInc;
            }

            return trees;
        }

    }
}
