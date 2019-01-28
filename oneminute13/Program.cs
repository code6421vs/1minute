using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oneminute13
{
    class Program
    {
        private string Take(object arg)
        {
            return "object parameter";
        }

        private string Take(string arg)
        {
            return "string parameter ";
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(p.Take(null));
            Console.ReadLine();
        }
    }
}
