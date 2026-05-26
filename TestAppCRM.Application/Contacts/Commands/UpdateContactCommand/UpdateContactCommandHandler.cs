using Mapster;
using MediatR;
using TestAppCRM.Application.Contacts.DTOs;
using TestAppCRM.Application.Interfaces;
using TestAppCRM.Application.Interfaces.Repositories;
using TestAppCRM.DomainModel.Exceptions;

namespace TestAppCRM.Application.Contacts.Commands.UpdateContactCommand;

public class UpdateContactHandler : IRequestHandler<UpdateContactCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IContactRepository _repository;

    public UpdateContactHandler(IUnitOfWork unitOfWork, IContactRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task<Guid> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _repository.GetContactByIdAsync(request.Id, cancellationToken);

        if (contact is null)
        {
            throw new NotFoundException("Incorrect contact id");
        }

        request.Adapt(contact);

        _repository.Update(contact);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return contact.Id;
    }
}