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
        var paginatedContacts = await _repository.GetPaginatedAsync(
            request.Page,
            request.PageSize,
            cancellationToken);

        return new PaginatedPageResponse<ContactResponseDto>
        {
            Items = paginatedContacts.Items.Adapt<List<ContactResponseDto>>(),

            Page = paginatedContacts.Page,

            PageSize = paginatedContacts.PageSize,

            TotalCount = paginatedContacts.TotalCount
        };
    }
}