using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace oneminute9
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        static Expression<Func<T, bool>> DynamicWhere<T>(IDictionary<string, object> conditions)
        {
            ParameterExpression pe = Expression.Parameter(typeof(T), "a");
            BinaryExpression be = null;
            foreach (var item in conditions)
            {
                MemberExpression me = Expression.Property(pe, item.Key);
                ConstantExpression ce = Expression.Constant(item.Value,
                    typeof(T).GetProperty(item.Key).PropertyType);
                if (be == null)
                    be = Expression.Equal(me, ce);
                else
                    be = BinaryExpression.And(be, Expression.Equal(me, ce));
            }
            return Expression.Lambda<Func<T, bool>>(
                be, new[] { pe });
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

            var expr = DynamicWhere<Person>(new Dictionary<string, object>
            {
                {"Name", "code6421" },
                {"Age", 12 },
            });

            foreach (var item in list.AsQueryable().Where(expr))
                Console.WriteLine(item.Name);
            Console.ReadLine();
        }
    }
}
