namespace UrbanPulse.Api.Parsers;

public class QueryStringsOptions
{
    public string Filters { get; set; } = string.Empty;
    public string Sorts { get; set; } = string.Empty;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
