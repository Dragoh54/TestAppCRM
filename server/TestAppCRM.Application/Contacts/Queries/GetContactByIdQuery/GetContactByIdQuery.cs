using MediatR;
using TestAppCRM.Application.Contacts.DTOs;

namespace TestAppCRM.Application.Contacts.Queries.GetContactByIdQuery;

public record GetContactByIdQuery : IRequest<ContactResponseDto>
{
    public GetContactByIdQuery(GetContactByIdRequestDto request)
    {
        Id = request.Id;
    }
    
    public Guid Id { get; set; }
}