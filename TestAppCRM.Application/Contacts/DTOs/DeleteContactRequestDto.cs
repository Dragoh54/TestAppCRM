namespace TestAppCRM.Application.Contacts.DTOs;

public record DeleteContactRequest
{
    public Guid Id { get; init; }
}