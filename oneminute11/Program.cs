using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace oneminute11
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public static class ExpressionHelper<T>
        {
            public static Expression<Func<T, bool>> Create(Expression<Func<T, bool>> func) => func;

            public static Expression<Func<T, bool>> And(Expression<Func<T, bool>> source, Expression<Func<T, bool>> expr)
            {
                ParameterExpression pe = Expression.Parameter(typeof(T), "a");
                return Expression.Lambda<Func<T, bool>>(Expression.And(
                    Expression.Invoke(source, pe), Expression.Invoke(source, pe)), pe);
            }

            public static Expression<Func<T, bool>> Or(Expression<Func<T, bool>> source, Expression<Func<T, bool>> expr)
            {
                ParameterExpression pe = Expression.Parameter(typeof(T), "a");
                return Expression.Lambda<Func<T, bool>>(Expression.Or(
                    Expression.Invoke(source, pe), Expression.Invoke(source, pe)), pe);
            }
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

            var expr = ExpressionHelper<Person>.Create(a => a.Name == "code6421");
            expr = ExpressionHelper<Person>.And(expr, a => a.Age == 12);

            foreach (var item in list.AsQueryable().Where(expr))
                Console.WriteLine(item.Name);
            Console.ReadLine();
        }
    }
}
