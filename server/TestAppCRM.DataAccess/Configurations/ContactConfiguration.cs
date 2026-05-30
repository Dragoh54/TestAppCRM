using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAppCRM.DomainModel;
using TestAppCRM.DomainModel.Constraints;
using TestAppCRM.DomainModel.Entities;

namespace TestAppCRM.DataAccess.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .HasMaxLength(ContactConstrains.NAME_MAX_LENGTH)
            .IsRequired();
        
        builder.Property(x => x.MobilePhone)
            .HasMaxLength(ContactConstrains.MOBILE_PHONE_MAX_LENGTH)
            .IsRequired();
        
        builder.Property(x => x.JobTitle)
            .HasMaxLength(ContactConstrains.JOBTITLE_MAX_LENGTH)
            .IsRequired();
        
        builder.Property(x => x.BirthDate)
            .HasConversion(x => x, x => DateTime.SpecifyKind(x, DateTimeKind.Utc))
            .IsRequired();
    }
}