using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day05 : ASolution
    {
        string part1Examples = @"FBFBBFFRLR
BFFFBBFRRR
FFFBBBFRRR
BBFFBBFRLL
";

        public Day05() : base(05, 2020, "")
        {
            //DebugInput = part1Examples;
        }

        protected override string SolvePartOne()
        {
            var maxSeatId = 0;
            foreach (var item in Input.SplitByNewline())
            {
                var sear = new Seat(item);
                //Console.WriteLine($"{item} = Row {sear.Row}, Col {sear.Column}, SeatId {sear.SeatId}");
                if (sear.SeatId > maxSeatId)
                {
                    maxSeatId = sear.SeatId;
                }
            }
            return maxSeatId.ToString();

        }

        protected override string SolvePartTwo()
        {
            //var seats = new Seat[128,8];
            SortedList<int, Seat> seats = new SortedList<int, Seat>();
            var lowestSeat = int.MaxValue;
            foreach (var item in Input.SplitByNewline())
            {
                var sear = new Seat(item);
                //Console.WriteLine($"{item} = Row {sear.Row}, Col {sear.Column}, SeatId {sear.SeatId}");
                seats.Add(sear.SeatId, sear);
                if (sear.SeatId < lowestSeat)
                {
                    lowestSeat = sear.SeatId;
                }
            }

            while (true)
            {
                if (seats.ContainsKey(lowestSeat-1) && seats.ContainsKey(lowestSeat+1) && !seats.ContainsKey(lowestSeat))
                {
                    return lowestSeat.ToString();
                }
                lowestSeat++;
            }

        }

        class Seat
        {
            public int Row { get; private set; }
            public int Column { get; private set; }
            public int SeatId
            {
                get
                {
                    return (Row * 8) + Column;
                }
            }


            public Seat(string description)
            {
                var maxRows = 127;
                var maxColumns = 7;

                var debug = false;

                if (debug)
                {
                    Console.WriteLine(description);
                }

                int currentRowMin = 0;
                int currentRowMax = maxRows;

                int currentColMin = 0;
                int currentColMax = maxColumns;

                foreach (var item in description.ToCharArray())
                {
                    switch (item)
                    {
                        case 'F':
                            currentRowMax = currentRowMin + ((currentRowMax - currentRowMin) + 1) / 2 - 1;
                            break;
                        case 'B':
                            currentRowMin = currentRowMin + ((currentRowMax - currentRowMin) + 1) / 2;
                            break;

                        case 'L':
                            currentColMax = currentColMin + ((currentColMax - currentColMin) + 1) / 2 - 1;
                            break;
                        case 'R':
                            currentColMin = currentColMin + ((currentColMax - currentColMin) + 1) / 2;
                            break;

                    }
                    if (debug)
                    {
                        if (item == 'F' || item == 'B')
                        {
                            Console.WriteLine($"Rows {currentRowMin} .. {currentRowMax}");
                        }
                        else
                        {
                            Console.WriteLine($"Cols {currentColMin} .. {currentColMax}");
                        }
                    }

                }

                Row = currentRowMin;
                Column = currentColMin;

            }
        }
    }
}
