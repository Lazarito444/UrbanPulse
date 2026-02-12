namespace UrbanPulse.Domain.Common.Pagination;

public class FilterParam
{
    public string Field { get; set; } = string.Empty;
    public string Operator { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}

public class SortParam
{
    public string Field { get; set; } = string.Empty;
    public string Direction { get; set; } = string.Empty;
}

public class QueryParameters
{
    public List<FilterParam> Filters { get; set; } = [];
    public List<SortParam> Sorts { get; set; } = [];
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public int Skip
    {
        get { return (Page - 1) * PageSize; }
    }

    public int Take
    {
        get { return PageSize; }
    }
}

