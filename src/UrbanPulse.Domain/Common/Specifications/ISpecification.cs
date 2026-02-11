using System.Linq.Expressions;

namespace UrbanPulse.Domain.Common.Specifications;

public interface ISpecification<T, TResult>
{
    List<Expression<Func<T, bool>>> Criteria { get; }
    Expression<Func<T, TResult>> Selector { get; }
    List<OrderByExpression<T>> OrderExpressions { get; }
    int Take { get; }
    int Skip { get; }
    bool IsPagingEnabled { get; }
}
