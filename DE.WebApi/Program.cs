using System.Reflection;
using DE.Application.Interfaces;
using DE.Application.Configurations;
using DE.Application.Common.Mappings;
using DE.Persistence;
using DE.Persistence.Configurations;
using DE.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();
Configure(app, app.Environment);

try
{
    InitializeDatabase();
    app.Run();
}
catch (Exception exception)
{
    throw;
}

void InitializeDatabase()
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    DbInitializer.Initialize(context);
}

static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
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

static void Configure(IApplicationBuilder app, IHostEnvironment env)
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