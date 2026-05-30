using Mapster;
using MediatR;
using TestAppCRM.Application.Contacts.DTOs;
using TestAppCRM.Application.Interfaces.Repositories;
using TestAppCRM.DomainModel;
using TestAppCRM.DomainModel.Exceptions;

namespace TestAppCRM.Application.Contacts.Queries.GetContactByIdQuery;

public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ContactResponseDto>
{
    private readonly IContactRepository _repository;

    public GetContactByIdQueryHandler(IContactRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ContactResponseDto> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
        var contact = await _repository.GetContactByIdAsync(request.Id, cancellationToken);

        if (contact is null)
        {
            throw new NotFoundException("Incorrect contact id");
        }

        return contact.Adapt<ContactResponseDto>();
    }
}