using TestAppCRM.Application.Extensions;
using TestAppCRM.DataAccess.Extensions;
using TestAppCRM.Middlewares;

namespace TestAppCRM;

public class Startup
{
    private IConfiguration _configuration { get; }
    
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public static void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile("secrets.json", optional: false, reloadOnChange: true);
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTestAppCrmDbContext(_configuration);
        
        services.AddRepositories();
        services.AddUnitOfWork();

        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddMediatRServices();
        services.AddValidators();
        services.AddMapster();

        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseDefaultFiles();
        app.UseStaticFiles();
        app.UseRouting();
        
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}