using FluentValidation;
using TestAppCRM.Application.Pagination;

namespace TestAppCRM.Application.Contacts.Queries.GetPaginatedContactsQuery;

public class GetPaginatedContactsValidator : AbstractValidator<GetPaginatedContactsQuery>
{
    private const int MaxPageSize = 50;
    
    public GetPaginatedContactsValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(PaginatedListConstrains.MIN_PAGE);
        
        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(PaginatedListConstrains.MIN_PAGE_SIZE)
            .LessThanOrEqualTo(PaginatedListConstrains.MAX_PAGE_SIZE);
    }
}