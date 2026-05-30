using FluentValidation;
using TestAppCRM.DomainModel.Constraints;

namespace TestAppCRM.Application.Contacts.Commands.CreateContactCommand;

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(ContactConstrains.NAME_MAX_LENGTH);

        RuleFor(x => x.MobilePhone)
            .NotEmpty()
            .MaximumLength(ContactConstrains.MOBILE_PHONE_MAX_LENGTH)
            .Matches(ContactConstrains.MOBILE_PHONE_REGEX);

        RuleFor(x => x.JobTitle)
            .MaximumLength(ContactConstrains.JOBTITLE_MAX_LENGTH);

        RuleFor(x => x.BirthDate)
            .LessThan(DateTime.Now);
    }
}