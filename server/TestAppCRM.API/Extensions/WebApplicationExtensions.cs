using TestAppCRM.DataAccess.Context;
using TestAppCRM.DataAccess.DataSeed;

namespace TestAppCRM.Extensions;

public static class WebApplicationExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<TestAppCrmDbContext>();

        await DbInitializer.SeedAsync(context);
    }
}