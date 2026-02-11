using System.Linq.Expressions;

namespace UrbanPulse.Domain.Common.Specifications;

public abstract class BaseSpecification<T, TResult> : ISpecification<T, TResult>
{
    public List<Expression<Func<T, bool>>> Criteria { get; } = [];
    public Expression<Func<T, TResult>> Selector { get; private set; } = null!;
    public List<OrderByExpression<T>> OrderExpressions { get; } = [];
    public int Take { get; private set; }
    public int Skip { get; private set; }
    public bool IsPagingEnabled { get; private set; }

    protected void AddCriteria(Expression<Func<T, bool>> criteria) => Criteria.Add(criteria);

    protected void AddSelector(Expression<Func<T, TResult>> selector) => Selector = selector;

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderExpressions.Add(new OrderByExpression<T>(orderByExpression, OrderDirection.Ascending));
    }

    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderExpressions.Add(new OrderByExpression<T>(orderByDescExpression, OrderDirection.Descending));
    }

    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
    }
}
