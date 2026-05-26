using MediatR;
using TestAppCRM.Application.Contacts.DTOs;

namespace TestAppCRM.Application.Contacts.Queries.GetAllContactsQuery;

public record GetAllContactsQuery : IRequest<List<ContactResponseDto>>;