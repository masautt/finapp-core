using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repos.Tables;
using Services;
using Database;

namespace FinappCore;

public static class ServiceProviderFactory
{
    public static ServiceProvider BuildServiceProvider(string connectionString)
    {
        var services = new ServiceCollection();

        // DbContext registration
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString, npgsqlOptions => npgsqlOptions.EnableRetryOnFailure()));

        // Repos & Services
        services.AddTransient<BaseRepo>();
        services.AddTransient<BaseSvc>();

        return services.BuildServiceProvider();
    }
}