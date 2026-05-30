using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestAppCRM.Application.Interfaces;
using TestAppCRM.Application.Interfaces.Repositories;
using TestAppCRM.Application.Pagination;
using TestAppCRM.DataAccess.Context;
using TestAppCRM.DataAccess.DataSeed;
using TestAppCRM.DataAccess.Repositories;

namespace TestAppCRM.DataAccess.Extensions;

public static class DataAccessExtensions
{
    public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTestAppCrmDbContext(configuration);
        services.AddUnitOfWork();
        services.AddRepositories();
    }
    
    public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> query, int page, int pageSize, 
        CancellationToken cancellationToken = default)
    {
        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedList<T>(
            items,
            totalCount,
            page,
            pageSize);
    }
    
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IContactRepository, ContactRepository>();
    }

    private static void AddTestAppCrmDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TestAppCrmDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("TestAppCrmDbContext")));
    }
    
    private static void AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
    }
}