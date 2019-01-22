using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace oneminute12
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

            class MyExpressionVisitor : ExpressionVisitor
            {
                private ParameterExpression _replaceVar;
                protected override Expression VisitParameter(ParameterExpression node)
                {
                    if (node.Type == typeof(T))
                        return _replaceVar;
                    return base.VisitParameter(node);
                }

                public Expression<Func<T, bool>> ReplaceVars(Expression<Func<T, bool>> func) =>
                    (Expression<Func<T, bool>>)Visit(func);

                public MyExpressionVisitor(ParameterExpression replaceVar) => _replaceVar = replaceVar;
            }

            public static Expression<Func<T, bool>> Create(Expression<Func<T, bool>> func) => func;

            public static Expression<Func<T, bool>> And(Expression<Func<T, bool>> source, Expression<Func<T, bool>> expr)
            {
                ParameterExpression pe = Expression.Parameter(typeof(T), "a");
                var visitor = new MyExpressionVisitor(pe);
                var replaceSource = visitor.ReplaceVars(source);
                var replaceDest = visitor.ReplaceVars(expr);
                return Expression.Lambda<Func<T, bool>>(Expression.And(replaceSource.Body, replaceDest.Body), pe);
            }

            public static Expression<Func<T, bool>> Or(Expression<Func<T, bool>> source, Expression<Func<T, bool>> expr)
            {
                ParameterExpression pe = Expression.Parameter(typeof(T), "a");
                var visitor = new MyExpressionVisitor(pe);
                var replaceSource = visitor.ReplaceVars(source);
                var replaceDest = visitor.ReplaceVars(expr);
                return Expression.Lambda<Func<T, bool>>(Expression.Or(replaceSource.Body, replaceDest.Body), pe);
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
            expr = ExpressionHelper<Person>.Or(expr, a => a.Name == "ark");

            foreach (var item in list.AsQueryable().Where(expr))
                Console.WriteLine(item.Name);
            Console.ReadLine();
        }
    }
}
