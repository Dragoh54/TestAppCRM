using MediatR;
using TestAppCRM.Application.Contacts.DTOs;

namespace TestAppCRM.Application.Contacts.Commands.UpdateContactCommand;

public record UpdateContactCommand : IRequest<Guid>
{
    public UpdateContactCommand(UpdateContactRequestDto request)
    {
        Id = request.Id;
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