using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestAppCRM.Application.Interfaces;
using TestAppCRM.Application.Interfaces.Repositories;
using TestAppCRM.DataAccess.Context;
using TestAppCRM.DataAccess.Repositories;

namespace TestAppCRM.DataAccess.Extensions;

public static class DataAccessExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IContactRepository, ContactRepository>();
    }

    public static void AddTestAppCrmDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TestAppCrmDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("TestAppCrmDbContext")));
    }
    
    public static void AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
    }
}