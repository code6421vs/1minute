using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
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

        public class ExpressionHelper<T>
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

            private Expression<Func<T, bool>> _source;
            ParameterExpression _pe = Expression.Parameter(typeof(T), "a");

            public Expression<Func<T, bool>> Expr => _source;

            public static ExpressionHelper<T> Create(Expression<Func<T, bool>> func)
            {
                var result = new ExpressionHelper<T> { _source = func };
                return result;
            }

            public ExpressionHelper<T> And(Expression<Func<T, bool>> expr)
            {
                var visitor = new MyExpressionVisitor(_pe);
                var replaceSource = visitor.ReplaceVars(_source);
                var replaceDest = visitor.ReplaceVars(expr);
                _source = Expression.Lambda<Func<T, bool>>(Expression.And(replaceSource.Body, replaceDest.Body), _pe);
                return this;
            }

            public ExpressionHelper<T> Or(Expression<Func<T, bool>> expr)
            {
                var visitor = new MyExpressionVisitor(_pe);
                var replaceSource = visitor.ReplaceVars(_source);
                var replaceDest = visitor.ReplaceVars(expr);
                _source = Expression.Lambda<Func<T, bool>>(Expression.Or(replaceSource.Body, replaceDest.Body), _pe);
                return this;
            }

            private ExpressionHelper()
            {

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

            var expr = ExpressionHelper<Person>.Create(
                a => a.Name == "code6421").And(
                a => a.Age == 12).Or(
                a => a.Name == "ark");

            foreach (var item in list.AsQueryable().Where(expr.Expr))
                Console.WriteLine(item.Name);
            Console.ReadLine();
        }
    }
}
