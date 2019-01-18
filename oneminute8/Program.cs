using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oneminute8
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        static IEnumerable<Person> FindPerson(IEnumerable<Person> source, string name, int? age = null)
        {
            if (name != null)
                source = source.Where(a => a.Name == name);
            if (age != null)
                source = source.Where(a => a.Age == age);
            return source;
        }

        static IEnumerable<Person> FindPerson2(IEnumerable<Person> source, string name, int? age = null)
        {
            IEnumerable<Person> c(object v) =>
                        v == null ? source : null;
            source = c(name) ?? source.Where(a => a.Name == name);
            source = c(age) ?? source.Where(a => a.Age == age);
            return source;
        }

        static void Main(string[] args)
        {
            var list = new Person[]
            {
                new Person() { Name = "code6421", Age = 12 },
                new Person() {Name = "mary", Age = 16},
                new Person() {Name = "ark", Age = 12},
                new Person() {Name = "jerry", Age = 14},
            };
            
            foreach (var item in FindPerson2(list, "code6421"))
                Console.WriteLine(item.Name);
            Console.ReadLine();
        }
    }
}
