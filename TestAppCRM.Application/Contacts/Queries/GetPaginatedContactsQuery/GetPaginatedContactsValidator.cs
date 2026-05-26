using FluentValidation;

namespace TestAppCRM.Application.Contacts.Queries.GetPaginatedContactsQuery;

public class GetPaginatedContactsValidator : AbstractValidator<GetPaginatedContactsQuery>
{
    private const int MaxPageSize = 50;
    
    public GetPaginatedContactsValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(0);
        
        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(MaxPageSize);
    }
}