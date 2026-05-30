using TestAppCRM;
using TestAppCRM.DataAccess.Extensions;
using TestAppCRM.Extensions;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
Startup.ConfigureBuilder(builder);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

await app.InitializeDatabaseAsync();

startup.Configure(app, app.Environment);

app.Run();