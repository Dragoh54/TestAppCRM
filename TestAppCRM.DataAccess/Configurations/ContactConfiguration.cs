using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAppCRM.DomainModel;

namespace TestAppCRM.DataAccess.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .IsRequired();
        
        builder.Property(x => x.MobilePhone)
            .HasMaxLength(256)
            .IsRequired();
        
        builder.Property(x => x.JobTitle)
            .HasMaxLength(256)
            .IsRequired();
        
        builder.Property(x => x.BirthDate)
            .HasConversion(x => x, x => DateTime.SpecifyKind(x, DateTimeKind.Utc))
            .IsRequired();
    }
}