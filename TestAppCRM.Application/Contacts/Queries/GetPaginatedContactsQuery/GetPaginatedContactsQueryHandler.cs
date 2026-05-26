using Mapster;
using MediatR;
using TestAppCRM.Application.Contacts.DTOs;
using TestAppCRM.Application.Interfaces.Repositories;
using TestAppCRM.Application.Pagination;

namespace TestAppCRM.Application.Contacts.Queries.GetPaginatedContactsQuery;

public class GetPagedContactsHandler : IRequestHandler<GetPaginatedContactsQuery, PaginatedPageResponse<ContactResponseDto>>
{
    private readonly IContactRepository _repository;

    public GetPagedContactsHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaginatedPageResponse<ContactResponseDto>> Handle(
        GetPaginatedContactsQuery request,
        CancellationToken cancellationToken)
    {
        var (items, totalCount) = await _repository.GetPaginatedAsync(
            request.Page,
            request.PageSize,
            cancellationToken);

        return new PaginatedPageResponse<ContactResponseDto>
        {
            Items = items.Adapt<List<ContactResponseDto>>(),

            Page = request.Page,

            PageSize = request.PageSize,

            TotalCount = totalCount
        };
    }
}