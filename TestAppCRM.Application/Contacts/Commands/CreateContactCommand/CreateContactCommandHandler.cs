using Mapster;
using MediatR;
using TestAppCRM.Application.Contacts.DTOs;
using TestAppCRM.Application.Interfaces;
using TestAppCRM.Application.Interfaces.Repositories;
using TestAppCRM.DomainModel;

namespace TestAppCRM.Application.Contacts.Commands.CreateContactCommand;

public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ContactResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IContactRepository _repository;
    
    public CreateContactCommandHandler(IUnitOfWork unitOfWork, IContactRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    
    public async Task<ContactResponseDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact()
        {
            Id = request.Id,
            Name = request.Name,
            MobilePhone = request.MobilePhone,
            JobTitle = request.JobTitle,
            BirthDate = request.BirthDate
        };
        
        await _repository.AddAsync(contact, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return contact.Adapt<ContactResponseDto>();
    }
}