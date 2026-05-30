using Mapster;
using MediatR;
using TestAppCRM.Application.Contacts.DTOs;
using TestAppCRM.Application.Interfaces.Repositories;

namespace TestAppCRM.Application.Contacts.Queries.GetAllContactsQuery;

public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, List<ContactResponseDto>>
{
    private readonly IContactRepository _repository;

    public GetAllContactsQueryHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ContactResponseDto>> Handle(
        GetAllContactsQuery request,
        CancellationToken cancellationToken)
    {
        var contacts = await _repository.GetContactsAsync(cancellationToken);

        return contacts.Adapt<List<ContactResponseDto>>();
    }
}