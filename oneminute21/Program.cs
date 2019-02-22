using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oneminute22
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Credit { get; set; }
            public int Credit1 { get; set; }
            public int Credit2 { get; set; }
            public int Credit3 { get; set; }
            public int Credit4 { get; set; }
            public int Credit5 { get; set; }
            public int Credit6 { get; set; }
            public int Credit7 { get; set; }
            public int Credit8 { get; set; }
            public int Credit9 { get; set; }
            public int Credit10 { get; set; }
            public int Credit11 { get; set; }
            public int Credit12 { get; set; }
            public int Credit13 { get; set; }
            public int Credit14 { get; set; }
            public int Credit15 { get; set; }
            public int Credit16 { get; set; }
            public int Credit17 { get; set; }
            public int Credit18 { get; set; }
        }

        struct PersonStruct
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Credit { get; set; }
            public int Credit1 { get; set; }
            public int Credit2 { get; set; }
            public int Credit3 { get; set; }
            public int Credit4 { get; set; }
            public int Credit5 { get; set; }
            public int Credit6 { get; set; }
            public int Credit7 { get; set; }
            public int Credit8 { get; set; }
            public int Credit9 { get; set; }
            public int Credit10 { get; set; }
            public int Credit11 { get; set; }
            public int Credit12 { get; set; }
            public int Credit13 { get; set; }
            public int Credit14 { get; set; }
            public int Credit15 { get; set; }
            public int Credit16 { get; set; }
            public int Credit17 { get; set; }
            public int Credit18 { get; set; }
        }

        static string TestPassByClass(Person p)
        {
            return p.Name + p.Age + p.Credit;
        }

        static string TestPassByStruct(PersonStruct p)
        {
            return p.Name + p.Age + p.Credit;
        }

        static void Benchmark(Action func, string title)
        {
            var sw = new Stopwatch();
            sw.Start();
            func();
            sw.Stop();
            Console.WriteLine($"{title} elapsed {sw.ElapsedMilliseconds} ms");
        }

        static void Main(string[] args)
        {
            int loopSize = 10000000;
            Benchmark(() =>
            {
                var p = new Person()
                {
                    Name = "code6421",
                    Age = 12,
                    Credit = 120000
                };
                for (var i = 0; i < loopSize; i++)
                    TestPassByClass(p);
            }, "By Class");

            Benchmark(() =>
            {
                var p = new PersonStruct()
                {
                    Name = "code6421",
                    Age = 12,
                    Credit = 120000
                };
                for (var i = 0; i < loopSize; i++)
                    TestPassByStruct(p);
            }, "By Struct");

            Benchmark(() =>
            {
                var p = new Person()
                {
                    Name = "code6421",
                    Age = 12,
                    Credit = 120000
                };
                for (var i = 0; i < loopSize; i++)
                    TestPassByClass(p);
            }, "By Class");

            Benchmark(() =>
            {
                var p = new PersonStruct()
                {
                    Name = "code6421",
                    Age = 12,
                    Credit = 120000
                };
                for (var i = 0; i < loopSize; i++)
                    TestPassByStruct(p);
            }, "By Struct");

            Benchmark(() =>
            {
                var p = new Person()
                {
                    Name = "code6421",
                    Age = 12,
                    Credit = 120000
                };
                for (var i = 0; i < loopSize; i++)
                    TestPassByClass(p);
            }, "By Class");

            Benchmark(() =>
            {
                var p = new PersonStruct()
                {
                    Name = "code6421",
                    Age = 12,
                    Credit = 120000
                };
                for (var i = 0; i < loopSize; i++)
                    TestPassByStruct(p);
            }, "By Struct");

            Console.ReadLine();
        }
    }
}
