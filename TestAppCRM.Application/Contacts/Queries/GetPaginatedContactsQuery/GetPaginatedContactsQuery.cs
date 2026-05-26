using MediatR;
using TestAppCRM.Application.Contacts.DTOs;
using TestAppCRM.Application.Pagination;

namespace TestAppCRM.Application.Contacts.Queries.GetPaginatedContactsQuery;

public record GetPaginatedContactsQuery : IRequest<PaginatedPageResponse<ContactResponseDto>>
{
    public GetPaginatedContactsQuery(PaginatedPageRequest request)
    {
        Page = request.Page;
        PageSize = request.PageSize;
    }
    
    public int Page = 1;
    public int PageSize = 10;
}