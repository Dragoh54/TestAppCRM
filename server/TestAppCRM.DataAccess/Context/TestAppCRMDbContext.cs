using Microsoft.EntityFrameworkCore;
using TestAppCRM.DomainModel;
using TestAppCRM.DomainModel.Entities;

namespace TestAppCRM.DataAccess.Context;

public class TestAppCrmDbContext : DbContext
{
    public TestAppCrmDbContext(DbContextOptions<TestAppCrmDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Contact> Contacts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(TestAppCrmDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}