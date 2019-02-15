using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oneminute19
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Credit { get; set; }
        }

        static void Main(string[] args)
        {
            var list = new Person[]
            {
                new Person() { Name = "1", Age = 12, Credit = 1000 },
                new Person() { Name = "2", Age = 13, Credit = 2000 },
                new Person() { Name = "3", Age = 14, Credit = 3000 },
            };

            var r = list.Aggregate((SumOfAge : 0, SumOfCredit: 0), (seed, x) =>
            {
                seed.SumOfAge += x.Age;
                seed.SumOfCredit += x.Credit;
                return seed;
            });
            Console.WriteLine($"SumAge: {r.SumOfAge}, SumCredit: {r.SumOfCredit}");
        }
    }
}
