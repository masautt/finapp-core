using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace FinappCore.Tests;

public static class TestServiceInitializer
{
    private static ServiceProvider? _provider;

    // Call this before your tests to get the service provider
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

        // Build DI container
        if (connectionString != null) _provider = ServiceProviderFactory.BuildServiceProvider(connectionString);

        return _provider;
    }

    // Helper to directly get a service
    public static T GetService<T>() where T : notnull
        => GetServiceProvider().GetRequiredService<T>();
}