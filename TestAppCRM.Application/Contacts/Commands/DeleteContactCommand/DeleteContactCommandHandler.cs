using Mapster;
using MediatR;
using TestAppCRM.Application.Contacts.DTOs;
using TestAppCRM.Application.Interfaces;
using TestAppCRM.Application.Interfaces.Repositories;
using TestAppCRM.DomainModel.Exceptions;

namespace TestAppCRM.Application.Contacts.Commands.DeleteContactCommand;

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, ContactResponseDto>
{
    private readonly IContactRepository _contactRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteContactCommandHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork)
    {
        _contactRepository = contactRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ContactResponseDto> Handle(DeleteContactCommand command, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetContactByIdAsync(command.Id, cancellationToken);

        if (contact is null)
        {
            throw new NotFoundException("Incorrect contact id");
        }
        
        _contactRepository.Delete(contact);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return contact.Adapt<ContactResponseDto>();
    }
}