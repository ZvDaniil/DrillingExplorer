using System.Reflection;

using Serilog;

using DE.Application.Interfaces;
using DE.Application.Configurations;
using DE.Application.Common.Mappings;

using DE.Persistence;
using DE.Persistence.Configurations;

using DE.WebApi.Middleware;

namespace DE.WebApi;

public static class App
{
    public static void Configure(IApplicationBuilder app, IHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }

        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }

    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
        });

        services.AddApplication();
        services.AddPersistence(configuration);

        services.AddControllers();
        services.AddSwaggerGen();
    }

    public static void ConfigureLogging(ILoggingBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        builder.ClearProviders();
        builder.AddSerilog();
    }

    public static void InitializeDatabase(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        DbInitializer.Initialize(context);
    }
}