using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;

namespace FinappCore.Tests;

public class ProgramTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ProgramTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;

        // Build configuration from appsettings.json
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true)
            .Build();

        // Configure FinappSvcFactory once for all tests
        var connectionString = configuration.GetConnectionString("FinappDatabase");
        FinappSvcFactory.Configure(connectionString);
    }

    [Fact]
    public async Task CanGetAllBudgets()
    {
        // Use the factory to create the service (no connection string needed)
        var budgetService = FinappSvcFactory.CreateBudgetSvc();

        var budgets = await budgetService.GetAllBudgetsAsync();

        Assert.NotNull(budgets);
        _testOutputHelper.WriteLine($"Budgets count: {budgets.Count}");
    }
}