namespace TestAppCRM.Application.Pagination;

public class PaginatedList<T>
{
    public IReadOnlyCollection<T> Items { get; init; }

    public int Page { get; init; }

    public int PageSize { get; init; }

    public int TotalCount { get; init; }

    public int TotalPages =>
        (int)Math.Ceiling((double)TotalCount / PageSize);

    public PaginatedList(
        IReadOnlyCollection<T> items,
        int totalCount,
        int page,
        int pageSize)
    {
        Items = items;

        TotalCount = totalCount;

        Page = page;

        PageSize = pageSize;
    }
}