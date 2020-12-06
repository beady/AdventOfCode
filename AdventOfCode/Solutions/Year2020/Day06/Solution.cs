using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day06 : ASolution
    {
        string day1Sample2 = @"abc

a
b
c

ab
ac

a
a
a
a

b";
        public Day06() : base(06, 2020, "")
        {
            //DebugInput = day1Sample2;
        }

        protected override string SolvePartOne()
        {
            var parentGroup = new List<GroupSurvey>();

            var currentGroup = new GroupSurvey();
            parentGroup.Add(currentGroup);
            foreach (var item in Input.SplitByNewline())
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    currentGroup = new GroupSurvey();
                    parentGroup.Add(currentGroup);
                    continue;
                }
                var response = new Survey(item);
                currentGroup.items.Add(response);
            }

            var yeses = parentGroup.Sum(x => x.CountAnswers());

            return yeses.ToString();
        }

        protected override string SolvePartTwo()
        {
            var parentGroup = new List<GroupAllSurvey>();

            var currentGroup = new GroupAllSurvey();
            parentGroup.Add(currentGroup);
            foreach (var item in Input.SplitByNewline())
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    currentGroup = new GroupAllSurvey();
                    parentGroup.Add(currentGroup);
                    continue;
                }
                var response = new Survey(item);
                currentGroup.items.Add(response);
            }

            var yeses = parentGroup.Sum(x => x.CountAnswers());

            return yeses.ToString();
        }



        public record Survey  (bool a, bool b, bool c, bool d, bool e, bool f, bool g, bool h, bool i, bool j, bool k, bool l, bool m, bool n, bool o, bool p, bool q, bool r, bool s, bool t, bool u, bool v, bool w, bool x, bool y, bool z) : ISurvey
        {
            public Survey(string initialiser) : this(
                initialiser.Contains('a'),
                initialiser.Contains('b'),
                initialiser.Contains('c'),
                initialiser.Contains('d'),
                initialiser.Contains('e'),
                initialiser.Contains('f'),
                initialiser.Contains('g'),
                initialiser.Contains('h'),
                initialiser.Contains('i'),
                initialiser.Contains('j'),
                initialiser.Contains('k'),
                initialiser.Contains('l'),
                initialiser.Contains('m'),
                initialiser.Contains('n'),
                initialiser.Contains('o'),
                initialiser.Contains('p'),
                initialiser.Contains('q'),
                initialiser.Contains('r'),
                initialiser.Contains('s'),
                initialiser.Contains('t'),
                initialiser.Contains('u'),
                initialiser.Contains('v'),
                initialiser.Contains('w'),
                initialiser.Contains('x'),
                initialiser.Contains('y'),
                initialiser.Contains('z'))
            {
            }
        }

        public class GroupSurvey : ISurvey
        {
            public List<ISurvey> items = new List<ISurvey>();
            public bool a { get => items.Any(x => x.a); }
            public bool b { get => items.Any(x => x.b); }
            public bool c { get => items.Any(x => x.c); }
            public bool d { get => items.Any(x => x.d); }
            public bool e { get => items.Any(x => x.e); }
            public bool f { get => items.Any(x => x.f); }
            public bool g { get => items.Any(x => x.g); }
            public bool h { get => items.Any(x => x.h); }
            public bool i { get => items.Any(x => x.i); }
            public bool j { get => items.Any(x => x.j); }
            public bool k { get => items.Any(x => x.k); }
            public bool l { get => items.Any(x => x.l); }
            public bool m { get => items.Any(x => x.m); }
            public bool n { get => items.Any(x => x.n); }
            public bool o { get => items.Any(x => x.o); }
            public bool p { get => items.Any(x => x.p); }
            public bool q { get => items.Any(x => x.q); }
            public bool r { get => items.Any(x => x.r); }
            public bool s { get => items.Any(x => x.s); }
            public bool t { get => items.Any(x => x.t); }
            public bool u { get => items.Any(x => x.u); }
            public bool v { get => items.Any(x => x.v); }
            public bool w { get => items.Any(x => x.w); }
            public bool x { get => items.Any(x => x.x); }
            public bool y { get => items.Any(x => x.y); }
            public bool z { get => items.Any(x => x.z); }

        }

        public class GroupAllSurvey : ISurvey
        {
            public List<ISurvey> items = new List<ISurvey>();
            public bool a { get => items.All(x => x.a); }
            public bool b { get => items.All(x => x.b); }
            public bool c { get => items.All(x => x.c); }
            public bool d { get => items.All(x => x.d); }
            public bool e { get => items.All(x => x.e); }
            public bool f { get => items.All(x => x.f); }
            public bool g { get => items.All(x => x.g); }
            public bool h { get => items.All(x => x.h); }
            public bool i { get => items.All(x => x.i); }
            public bool j { get => items.All(x => x.j); }
            public bool k { get => items.All(x => x.k); }
            public bool l { get => items.All(x => x.l); }
            public bool m { get => items.All(x => x.m); }
            public bool n { get => items.All(x => x.n); }
            public bool o { get => items.All(x => x.o); }
            public bool p { get => items.All(x => x.p); }
            public bool q { get => items.All(x => x.q); }
            public bool r { get => items.All(x => x.r); }
            public bool s { get => items.All(x => x.s); }
            public bool t { get => items.All(x => x.t); }
            public bool u { get => items.All(x => x.u); }
            public bool v { get => items.All(x => x.v); }
            public bool w { get => items.All(x => x.w); }
            public bool x { get => items.All(x => x.x); }
            public bool y { get => items.All(x => x.y); }
            public bool z { get => items.All(x => x.z); }

        }

    }

    public interface ISurvey
    {
        bool a { get; }
        bool b { get; }
        bool c { get; }
        bool d { get; }
        bool e { get; }
        bool f { get; }
        bool g { get; }
        bool h { get; }
        bool i { get; }
        bool j { get; }
        bool k { get; }
        bool l { get; }
        bool m { get; }
        bool n { get; }
        bool o { get; }
        bool p { get; }
        bool q { get; }
        bool r { get; }
        bool s { get; }
        bool t { get; }
        bool u { get; }
        bool v { get; }
        bool w { get; }
        bool x { get; }
        bool y { get; }
        bool z { get; }

    }


    public static class ISurveyExtensions
    {
        public static int CountAnswers(this ISurvey survey)
        {
            return (survey.a ? 1 : 0) +
                (survey.b ? 1 : 0) +
                (survey.c ? 1 : 0) +
                (survey.d ? 1 : 0) +
                (survey.e ? 1 : 0) +
                (survey.f ? 1 : 0) +
                (survey.g ? 1 : 0) +
                (survey.h ? 1 : 0) +
                (survey.i ? 1 : 0) +
                (survey.j ? 1 : 0) +
                (survey.k ? 1 : 0) +
                (survey.l ? 1 : 0) +
                (survey.m ? 1 : 0) +
                (survey.n ? 1 : 0) +
                (survey.o ? 1 : 0) +
                (survey.p ? 1 : 0) +
                (survey.q ? 1 : 0) +
                (survey.r ? 1 : 0) +
                (survey.s ? 1 : 0) +
                (survey.t ? 1 : 0) +
                (survey.u ? 1 : 0) +
                (survey.v ? 1 : 0) +
                (survey.w ? 1 : 0) +
                (survey.x ? 1 : 0) +
                (survey.y ? 1 : 0) +
                (survey.z ? 1 : 0);

        }

    }

}
