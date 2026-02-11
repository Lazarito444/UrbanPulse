using System.Linq.Expressions;
using UrbanPulse.Domain.Common.Specifications;

namespace UrbanPulse.Infrastructure;

internal static class SpecificationEvaluator<TEntity, TResult> where TEntity : class
{
    public static IQueryable<TResult> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity, TResult> spec)
    {
        ArgumentNullException.ThrowIfNull(spec.Selector);

        IQueryable<TEntity> query = inputQuery;

        foreach (Expression<Func<TEntity, bool>> criterion in spec.Criteria)
        {
            query = query.Where(criterion);
        }

        if (spec.OrderExpressions.Any())
        {
            IOrderedQueryable<TEntity> orderedQuery = null!;

            for (int i = 0; i < spec.OrderExpressions.Count; i++)
            {
                OrderByExpression<TEntity> orderExpr = spec.OrderExpressions[i];

                bool isFirst = i == 0;
                if (isFirst)
                {
                    orderedQuery = orderExpr.Direction == OrderDirection.Ascending
                        ? query.OrderBy(orderExpr.Expression)
                        : query.OrderByDescending(orderExpr.Expression);
                }
                else
                {
                    orderedQuery = orderExpr.Direction == OrderDirection.Ascending
                        ? orderedQuery.ThenBy(orderExpr.Expression)
                        : orderedQuery.ThenByDescending(orderExpr.Expression);
                }
            }
            query = orderedQuery;
        }

        if (spec.IsPagingEnabled)
        {
            query = query.Skip(spec.Skip).Take(spec.Take);
        }

        return query.Select(spec.Selector);
    }
}
