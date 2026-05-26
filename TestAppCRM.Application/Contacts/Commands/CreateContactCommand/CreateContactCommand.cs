using MediatR;
using TestAppCRM.Application.Contacts.DTOs;

namespace TestAppCRM.Application.Contacts.Commands.CreateContactCommand;

public record CreateContactCommand : IRequest<ContactResponseDto>
{
    public CreateContactCommand()
    {
    }

    public CreateContactCommand(CreateContactRequestDto request)
    {
        Id = Guid.NewGuid();
        Name = request.Name;
        MobilePhone = request.MobilePhone;
        JobTitle = request.JobTitle;
        BirthDate = request.BirthDate;
    }
    
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string MobilePhone { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public DateTime BirthDate { get; set; }
}