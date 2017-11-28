using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    public class Operator<T>
    {
        private static readonly Func<double, T, T> multiplyD = CreateExpression<double, T, T>(new Func<Expression, Expression, BinaryExpression>(Expression.Multiply));
        private static readonly Func<int, T, T> multiply = CreateExpression<int, T, T>(new Func<Expression, Expression, BinaryExpression>(Expression.Multiply));
        private static readonly Func<T, T, T> add = CreateExpression<T, T, T>(new Func<Expression, Expression, BinaryExpression>(Expression.Add));
        private static readonly Func<T, T, T> divide = CreateExpression<T, T, T>(new Func<Expression, Expression, BinaryExpression>(Expression.Divide));

        public static Func<int, T, T> Multiply
        {
            get { return Operator<T>.multiply; }
        }

        public static Func<double, T, T> MultiplyD
        {
            get { return Operator<T>.multiplyD; }
        }

        public static Func<T, T, T> Add
        {
            get { return Operator<T>.add; }
        }

        public static Func<T, T, T> Divide
        {
            get { return Operator<T>.divide; }
        }

        private static Func<TArg1, TArg2, TResult> CreateExpression<TArg1, TArg2, TResult>(Func<Expression, Expression, BinaryExpression> body)
        {
            ParameterExpression parameterExpression1 = Expression.Parameter(typeof(TArg1), "lhs");
            ParameterExpression parameterExpression2 = Expression.Parameter(typeof(TArg2), "rhs");
            try
            {
                return Expression.Lambda<Func<TArg1, TArg2, TResult>>(
                    (Expression)body((Expression)parameterExpression1,
                    (Expression)parameterExpression2),
                    new ParameterExpression[2] { parameterExpression1, parameterExpression2 }
                ).Compile();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return (Func<TArg1, TArg2, TResult>)delegate { throw new InvalidOperationException(msg); };
            }
        }
    }
}
