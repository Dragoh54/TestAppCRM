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
        services.AddDataAccess(_configuration);

        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddApplication();

        services.AddSwaggerGen();
        
        services.AddCors(options =>
        {
            options.AddPolicy("Client", policy =>
            {
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseDefaultFiles();
        app.UseStaticFiles();
        app.UseRouting();
        
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseCors("Client");
        
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}