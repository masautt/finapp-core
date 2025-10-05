using Database;
using FinappCore.Tests.SvcTests.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repos.Interfaces;
using Repos.Shared;
using Repos.Tables;
using Services.Interfaces;
using Services.Shared;
using Services.Tables;

namespace FinappCore.Tests;

public static class TestServiceInitializer
{
    private static ServiceProvider? _provider;

    public static ServiceProvider? GetServiceProvider()
    {
        if (_provider != null) return _provider;

        // Load configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("Database");

        if (connectionString != null)
            _provider = BuildServiceProvider(connectionString);

        return _provider;
    }

    public static T GetService<T>() where T : notnull
        => GetServiceProvider().GetRequiredService<T>();

    // Moved ServiceProviderFactory logic here
    private static ServiceProvider BuildServiceProvider(string connectionString)
    {
        var services = new ServiceCollection();

        // Build DbContext options
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        // Register DbContext
        services.AddSingleton(new AppDbContext(options));

        // Repositories
        services.AddScoped<ICarRepo, CarRepo>();
        services.AddSingleton<CommonRepo>();
        services.AddSingleton<DateRepo>();

        // Services
        services.AddScoped<ICarSvc, CarSvc>();
        services.AddScoped<IPaycheckSvc, PaycheckSvc>();
        services.AddScoped<DateSvc>();
        services.AddScoped(typeof(CommonSvc<>));
        services.AddScoped<IPaycheckRepo, PaycheckRepo>();


        return services.BuildServiceProvider();
    }
}