using Serilog;
using DE.WebApi;

var builder = WebApplication.CreateBuilder(args);
App.ConfigureLogging(builder.Logging);
App.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();
App.Configure(app, app.Environment);

try
{
    App.InitializeDatabase(app);
    app.Run();
}
catch (Exception exception)
{
    Log.Fatal(exception, "An error occurred while app initialization");
}
finally
{
    Log.CloseAndFlush();
}