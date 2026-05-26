namespace TestAppCRM.Application.Contacts.DTOs;

public record ContactDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string MobilePhone { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public DateTime BirthDate { get; set; }
}