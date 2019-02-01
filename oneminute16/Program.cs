using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oneminute16
{
    struct MyStruct
    {
        public readonly decimal Value1;
        public readonly decimal Value2;

        public MyStruct(decimal v1, decimal v2)
        {
            Value1 = v1;
            Value2 = v2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var s1 = new MyStruct(15, 12);
            var s2 = new MyStruct(15.0m, 12);
            if (s1.Equals(s2))
                Console.WriteLine("is same");
            if (s1.GetHashCode() == s2.GetHashCode())
                Console.WriteLine("is same");
            Console.ReadLine();
        }
    }
}
