using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repos.Tables.Shared;
using Repos.Transums;
using Services.Tables;
using Services.Tables.Interfaces;
using Services.Tables.Shared;
using Services.Transums;

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

    private static ServiceProvider BuildServiceProvider(string connectionString)
    {
        var services = new ServiceCollection();

        // Build DbContext options
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        // Register DbContext
        services.AddScoped(_ => new AppDbContext(options));

        // Base Repositories
        services.AddScoped<CommonRepo>();
        services.AddScoped<DateRepo>();
        services.AddScoped<EntityRepo>();

        // Base Services (optional, only if you use them directly elsewhere)
        services.AddScoped(typeof(DateSvc<>));
        services.AddScoped(typeof(CommonSvc<>));

        // Concrete Services (Tables)
        services.AddScoped<IBudgetSvc, BudgetSvc>();
        services.AddScoped<ICarSvc, CarSvc>();
        services.AddScoped<IContributionSvc, ContributionSvc>();
        services.AddScoped<IHousingSvc, HousingSvc>();
        services.AddScoped<IPaycheckSvc, PaycheckSvc>();
        services.AddScoped<ISideGigSvc, SideGigSvc>();
        services.AddScoped<ITransactionSvc, TransactionSvc>();

        // Transum Services
        services.AddScoped<TransumBusSvc>();
        services.AddScoped<TransumCatSvc>();

        // Transum Repos
        services.AddScoped<TransumBusRepo>();
        services.AddScoped<TransumCatRepo>();

        return services.BuildServiceProvider();
    }
}