using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientExpressions
{
    public class CalculatorExpressionVisitor : ExpressionVisitor
    {
        private readonly Dictionary<ExpressionResult, ExpressionResult[]> execute =
            new Dictionary<ExpressionResult, ExpressionResult[]>();

        public Dictionary<ExpressionResult, ExpressionResult[]> GetExecuteBefore(Expression expression)
        {
            Visit(expression);
            return execute;
        }


        public override Expression Visit(Expression node)
        {
            return null;
        }
    }
}