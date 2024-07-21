using System.Linq.Expressions;
using SqlKata;

namespace CleanCodeArchitecture.Infrastructure.SqlKataDapper.Extensions;

public static class ExpressionsExtensions
{
    public static Query ToSqlWhereClause<T>(this Query query, Expression<Func<T, bool>> expression)
    {
        var binaryExpression = (BinaryExpression)expression.Body;
        var left = binaryExpression.Left;
        var right = binaryExpression.Right;

        // Assuming 'left' and 'right' are MemberExpressions representing properties
        var leftColumnName = ((MemberExpression)left).Member.Name;
        var rightValue = Expression.Lambda(right).Compile().DynamicInvoke();

        return query.Where(leftColumnName, rightValue);

       
    }
}