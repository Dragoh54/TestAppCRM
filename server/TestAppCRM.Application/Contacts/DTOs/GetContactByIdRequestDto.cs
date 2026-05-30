namespace TestAppCRM.Application.Contacts.DTOs;

public record GetContactByIdRequestDto
{
    public Guid Id { get; init; }
}