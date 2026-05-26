using FluentValidation;

namespace TestAppCRM.Application.Contacts.Commands.CreateContactCommand;

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    private const string PhoneRegex = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";
    
    public CreateContactCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(x => x.MobilePhone)
            .NotEmpty()
            .MaximumLength(20)
            .Matches(PhoneRegex);

        RuleFor(x => x.JobTitle)
            .MaximumLength(256);

        RuleFor(x => x.BirthDate)
            .LessThan(DateTime.Now);
    }
}