namespace TestAppCRM.Application.Pagination;

public record PaginatedPageRequest
{
    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 10;
}