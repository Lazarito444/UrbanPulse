using System.Linq.Expressions;

namespace UrbanPulse.Domain.Common.Specifications;

public enum OrderDirection
{
    Ascending,
    Descending
}

public class OrderByExpression<T>
{
    public Expression<Func<T, object>> Expression { get; }
    public OrderDirection Direction { get; }

    public OrderByExpression(Expression<Func<T, object>> expression, OrderDirection direction)
    {
        Expression = expression;
        Direction = direction;
    }
}
