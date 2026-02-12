using System.Linq.Expressions;
using UrbanPulse.Domain.Common.DynamicExpressions;
using UrbanPulse.Domain.Common.Pagination;

namespace UrbanPulse.Domain.Common.Specifications;

public class DynamicSpecification<T> : BaseSpecification<T, T>
{
    public DynamicSpecification(QueryParameters parameters)
    {
        foreach (FilterParam filter in parameters.Filters)
        {
            Expression<Func<T, bool>>? expression = DynamicExpressionBuilder.BuildFilter<T>(filter.Field, filter.Operator, filter.Value);
            if (expression is not null)
            {
                AddCriteria(expression);
            }
        }

        foreach (SortParam sort in parameters.Sorts)
        {
            Expression<Func<T, object>>? expression = DynamicExpressionBuilder.BuildSort<T>(sort.Field);

            if (expression is null) continue;

            if (string.Equals(sort.Direction, "desc", StringComparison.OrdinalIgnoreCase))
            {
                AddOrderByDescending(expression);
            }
            else
            {
                AddOrderBy(expression);
            }
        }
    }
}
