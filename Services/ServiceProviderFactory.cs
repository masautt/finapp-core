using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repos.Shared;
using Services.Shared;

namespace Services;

public static class ServiceProviderFactory
{
    public static ServiceProvider BuildServiceProvider(string connectionString)
    {
        var services = new ServiceCollection();

        // DbContext registration
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString, npgsqlOptions => npgsqlOptions.EnableRetryOnFailure()));

        // Repos & Services
        services.AddTransient<CommonRepo>();
        services.AddTransient<CommonSvc>();

        return services.BuildServiceProvider();
    }
}