using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repos.Tables;
using Services.Tables;
using Services.Tables.Interfaces;
using Services.Tables.Shared;

namespace FinappCore.Tests;

public static class TestServiceInitializer
{
    private static ServiceProvider? _provider;

    public static ServiceProvider? GetServiceProvider()
    {
        if (_provider != null) return _provider;

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

    private static ServiceProvider BuildServiceProvider(string connectionString)
    {
        var services = new ServiceCollection();

        // DbContext
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        services.AddScoped(_ => new AppDbContext(options));

        // Base Repositories
        services.AddScoped<CommonRepo>();
        services.AddScoped<DateRepo>();
        services.AddScoped<EntityRepo>();

        // Base Services
        services.AddScoped(typeof(DateSvc<>));
        services.AddScoped(typeof(CommonSvc<>));

        // Table Services
        services.AddScoped<IBudgetSvc, BudgetSvc>();
        services.AddScoped<ICarSvc, CarSvc>();
        services.AddScoped<IContributionSvc, ContributionSvc>();
        services.AddScoped<IHousingSvc, HousingSvc>();
        services.AddScoped<IPaycheckSvc, PaycheckSvc>();
        services.AddScoped<ISideGigSvc, SideGigSvc>();
        services.AddScoped<ITransactionSvc, TransactionSvc>();

        return services.BuildServiceProvider();
    }
}
