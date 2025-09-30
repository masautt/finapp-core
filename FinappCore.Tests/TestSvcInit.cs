using Microsoft.Extensions.Configuration;

namespace FinappCore.Tests;

public static class TestServiceInitializer
{
    private static bool _isConfigured;

    public static void ConfigureFactory()
    {
        if (_isConfigured) return;

        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("Database");
        FinappSvcFactory.Configure(connectionString);

        _isConfigured = true;
    }
}