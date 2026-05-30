using Microsoft.EntityFrameworkCore;
using TestAppCRM.DataAccess.Context;
using TestAppCRM.DomainModel.Entities;

namespace TestAppCRM.DataAccess.DataSeed;

public static class DbInitializer
{
    public static async Task SeedAsync(TestAppCrmDbContext context)
    {
        await context.Database.MigrateAsync();

        if (await context.Contacts.AnyAsync())
        {
            return;
        }
        
        var contacts = CreateContacts();
        
        await context.Contacts.AddRangeAsync(contacts);

        await context.SaveChangesAsync();
    }

    private static List<Contact> CreateContacts()
    {
        List<Contact> contacts =
[
    new()
    {
        Id = Guid.NewGuid(),
        Name = "Freddy Fazbear",
        MobilePhone = "+87878787878",
        JobTitle = "Freddy Fazbear Pizza",
        BirthDate = new DateTime(1980, 1, 1, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "Leon S. Kennedy",
        MobilePhone = "+12025550101",
        JobTitle = "Raccoon City Police Department",
        BirthDate = new DateTime(1977, 6, 15, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "Albert Whiskas",
        MobilePhone = "+77777777777",
        JobTitle = "Umbrella",
        BirthDate = new DateTime(1977, 6, 15, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "Claire Redfield",
        MobilePhone = "+12025550102",
        JobTitle = "TerraSave Operative",
        BirthDate = new DateTime(1979, 3, 14, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "Dante",
        MobilePhone = "+12025550103",
        JobTitle = "Devil May Cry",
        BirthDate = new DateTime(1985, 10, 31, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "Vergil",
        MobilePhone = "+12025550104",
        JobTitle = "Son of Sparda",
        BirthDate = new DateTime(1985, 10, 31, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "Kazuma Kiryu",
        MobilePhone = "+12025550105",
        JobTitle = "Tojo Clan",
        BirthDate = new DateTime(1968, 6, 17, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "Goro Majima",
        MobilePhone = "+12025550106",
        JobTitle = "Majima Family",
        BirthDate = new DateTime(1964, 5, 14, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "Eleven",
        MobilePhone = "+12025550107",
        JobTitle = "Hawkins Lab Escapee",
        BirthDate = new DateTime(1971, 11, 4, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "Jim Hopper",
        MobilePhone = "+12025550108",
        JobTitle = "Hawkins Police Chief",
        BirthDate = new DateTime(1942, 9, 24, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "Billy Butcher",
        MobilePhone = "+12025550109",
        JobTitle = "The Boys",
        BirthDate = new DateTime(1972, 1, 12, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "Homelander",
        MobilePhone = "+12025550110",
        JobTitle = "The Seven",
        BirthDate = new DateTime(1981, 7, 4, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "Jill Valentine",
        MobilePhone = "+12025550111",
        JobTitle = "S.T.A.R.S.",
        BirthDate = new DateTime(1974, 2, 14, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "William Afton",
        MobilePhone = "+66666666666",
        JobTitle = "Afton Robotics",
        BirthDate = new DateTime(1950, 4, 1, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "Nero",
        MobilePhone = "+12025550112",
        JobTitle = "Devil Hunter",
        BirthDate = new DateTime(1990, 8, 20, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "Steve Harrington",
        MobilePhone = "+12025550113",
        JobTitle = "Scoops Ahoy",
        BirthDate = new DateTime(1966, 7, 22, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "Shadow the Hedgehog",
        MobilePhone = "+12025550114",
        JobTitle = "Ultimate Life Form",
        BirthDate = new DateTime(2001, 11, 15, 0, 0, 0, DateTimeKind.Utc),
    },

    new()
    {
        Id = Guid.NewGuid(),
        Name = "Solid Snake",
        MobilePhone = "+12025550115",
        JobTitle = "FOXHOUND",
        BirthDate = new DateTime(1972, 3, 3, 0, 0, 0, DateTimeKind.Utc),
    }
];

        return contacts;
    }
}