using Database;
using Repos;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Interfaces;

namespace FinappCore;

public static class Program
{
    private static AppDbContext CreateDbContext(string connectionString)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString, npgsqlOptions => npgsqlOptions.EnableRetryOnFailure())
            .Options;

        var dbContext = new AppDbContext(options);

        return dbContext;
    }

    public static IBudgetSvc CreateBudgetService(string connectionString)
    {
        var dbContext = CreateDbContext(connectionString);
        var repo = new BudgetRepo(dbContext);
        return new BudgetSvc(repo);
    }

}