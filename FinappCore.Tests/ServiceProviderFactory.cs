using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repos.Interfaces;
using Repos.Shared;
using Repos.Tables;
using Services.Interfaces;
using Services.Tables;

namespace FinappCore.Tests;

public static class ServiceProviderFactory
{
    public static ServiceProvider BuildServiceProvider(string connectionString)
    {
        var services = new ServiceCollection();

        // Build DbContext options
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        // Register DbContext
        services.AddSingleton(new AppDbContext(options));

        // Register CommonRepo
        services.AddSingleton<CommonRepo>();

        // Repositories
        services.AddScoped<ICarRepo, CarRepo>();

        // Services
        services.AddScoped<ICarSvc, CarSvc>();

        return services.BuildServiceProvider();
    }
}