using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;

namespace FinappCore.Tests;

public class ProgramTests(ITestOutputHelper testOutputHelper)
{
    private readonly IConfiguration _configuration = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)          // required
        .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true)     // optional
        .Build();

    // Build configuration from appsettings.json

    [Fact]
    public async Task CanGetAllBudgets()
    {
        // Get connection string from configuration
        var connectionString = _configuration.GetConnectionString("FinappDatabase");

        var budgetService = Program.CreateBudgetService(connectionString);
        var budgets = await budgetService.GetAllBudgetsAsync();

        Assert.NotNull(budgets);
        testOutputHelper.WriteLine($"Budgets count: {budgets.Count}");
    }
}