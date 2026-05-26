using Mapster;
using TestAppCRM.Application.Contacts.Commands.CreateContactCommand;
using TestAppCRM.Application.Contacts.Commands.UpdateContactCommand;
using TestAppCRM.Application.Contacts.DTOs;
using TestAppCRM.DomainModel;

namespace TestAppCRM.Application.Contacts.Mappings;

public class ContactMappings 
{
    public static void Register()
    {
        TypeAdapterConfig<Contact, ContactResponseDto>.NewConfig();

        TypeAdapterConfig<CreateContactCommand, Contact>.NewConfig();

        TypeAdapterConfig<UpdateContactCommand, Contact>.NewConfig();
    }
}