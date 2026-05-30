using FluentValidation;

namespace TestAppCRM.Application.Contacts.Queries.GetContactByIdQuery;

public class GetContactByIdQueryValidator : AbstractValidator<GetContactByIdQuery>
{
    public GetContactByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty);
    }
}