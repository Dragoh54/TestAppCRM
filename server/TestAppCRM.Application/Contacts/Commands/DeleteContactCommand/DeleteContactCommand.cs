using MediatR;
using TestAppCRM.Application.Contacts.DTOs;
using TestAppCRM.DomainModel;

namespace TestAppCRM.Application.Contacts.Commands.DeleteContactCommand;

public record DeleteContactCommand(Guid Id) : IRequest<ContactResponseDto>
{
    public Guid Id { get; set; } = Id;
}