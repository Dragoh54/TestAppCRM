using FluentValidation;

namespace TestAppCRM.Application.Contacts.Commands.DeleteContactCommand;

public class DeleteContactValidator : AbstractValidator<DeleteContactCommand>
{
    public DeleteContactValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty);
    }
}