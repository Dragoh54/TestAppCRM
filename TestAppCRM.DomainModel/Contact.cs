namespace TestAppCRM.DomainModel;

public class Contact
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string MobilePhone { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public DateTime BirthDate { get; set; }
}