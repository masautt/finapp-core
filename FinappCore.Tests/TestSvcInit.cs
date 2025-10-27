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
        services.AddScoped<TableCommonRepo>();
        services.AddScoped<TableDateRepo>();
        services.AddScoped<TableEntityRepo>();

        // Base Services
        services.AddScoped(typeof(DateTableSvc<>));
        services.AddScoped(typeof(CommonTableSvc<>));

        // Table Services
        services.AddScoped<IBudgetTableSvc, BudgetTableSvc>();
        services.AddScoped<ICarTableSvc, CarTableSvc>();
        services.AddScoped<IContributionTableSvc, ContributionTableSvc>();
        services.AddScoped<IHousingTableSvc, HousingTableSvc>();
        services.AddScoped<IPaycheckTableSvc, PaycheckTableSvc>();
        services.AddScoped<ISideGigTableSvc, SideGigTableSvc>();
        services.AddScoped<ITransactionSvc, TransactionTableSvc>();

        return services.BuildServiceProvider();
    }
}
