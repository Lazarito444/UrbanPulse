using UrbanPulse.Api.Parsers;
using UrbanPulse.Domain.Common.Pagination;

namespace UrbanPulse.Api.Extensions;

public static class QueryStringsOptionsExtensions
{
    extension(QueryStringsOptions opts)
    {
        public QueryParameters ToQueryParameters()
        {
            QueryParameters queryParameters = new QueryParameters();

            if (!string.IsNullOrWhiteSpace(opts.Filters))
            {
                string[] filterItems = filterItems = opts.Filters.Split(',', StringSplitOptions.RemoveEmptyEntries);

                foreach (string item in filterItems)
                {
                    string[] parts = item.Split(':', StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 3)
                    {
                        FilterParam filter = new FilterParam
                        {
                            Field = parts[0],
                            Operator = parts[1],
                            Value = parts[2]
                        };

                        queryParameters.Filters.Add(filter);
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(opts.Sorts))
            {
                string[] sortItems = opts.Sorts.Split(',');

                foreach (string item in sortItems)
                {
                    string[] parts = item.Split(':', StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                    {
                        SortParam sort = new SortParam
                        {
                            Field = parts[0],
                            Direction = parts[1]
                        };

                        queryParameters.Sorts.Add(sort);
                    }
                }
            }

            if (opts.PageNumber > 0)
            {
                queryParameters.Page = opts.PageNumber;
            }

            if (opts.PageSize > 0)
            {
                queryParameters.PageSize = opts.PageSize;
            }

            // ENFORCE MAX PAGE SIZE TO PREVENT PERFORMANCE ISSUES
            if (opts.PageSize > 100)
            {
                queryParameters.PageSize = 100;
            }

            return queryParameters;
        }
    }
}
