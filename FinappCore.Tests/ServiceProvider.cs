using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            _provider = ServiceProviderFactory.BuildServiceProvider(connectionString);

        return _provider;
    }

    public static T GetService<T>() where T : notnull
        => GetServiceProvider().GetRequiredService<T>();
}