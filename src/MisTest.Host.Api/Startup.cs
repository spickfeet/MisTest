using Microsoft.EntityFrameworkCore;
using MisTest.Application;
using MisTest.Host.Api.Middleware;
using MisTest.Infrastructure;

namespace MisTest.Host.Api;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _environment;

    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        _configuration = configuration;
        _environment = environment;
    }

    public void ConfigureServices(IServiceCollection services)
    {

        services.AddDbContext<MisTestDbContext>(options => 
            options.UseNpgsql(
                _configuration.GetConnectionString("mistestdb")));

        services.AddControllers();

        if (_environment.IsDevelopment())
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        services.ConfigureApplication();
        services.ConfigureInfrastucture();
        services.ConfigureAutoMapper();
    }

    public async Task ConfigureAsync(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<MisTestDbContext>();
            await db.Database.MigrateAsync();
        }

        app.UseMiddleWarePipeline();

        app.MapDefaultEndpoints();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}