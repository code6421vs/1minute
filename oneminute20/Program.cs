using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oneminute20
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Credit { get; set; }
        }

        struct PersonStruct
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Credit { get; set; }
        }

        static string TestPassByClass(Person p)
        {
            return p.Name + p.Age + p.Credit;
        }

        static string TestPassByStruct(PersonStruct p)
        {
            return p.Name + p.Age + p.Credit;
        }

        static void Main(string[] args)
        {

        }
    }
}
