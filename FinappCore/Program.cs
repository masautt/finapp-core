using Database;
using Microsoft.EntityFrameworkCore;
using Repos;
using Services;
using Services.Interfaces;
using System;

namespace FinappCore;

public static class FinappSvcFactory
{
    private static string _connectionString;

    /// <summary>
    /// Must be called once before creating any services.
    /// </summary>
    public static void Configure(string connectionString)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    private static AppDbContext CreateDbContext()
    {
        if (string.IsNullOrEmpty(_connectionString))
            throw new InvalidOperationException("FinappSvcFactory.Configure must be called first.");

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(_connectionString, npgsqlOptions => npgsqlOptions.EnableRetryOnFailure())
            .Options;

        return new AppDbContext(options);
    }

    public static IBudgetSvc CreateBudgetSvc()
    {
        var db = CreateDbContext();
        var repo = new BudgetRepo(db);
        return new BudgetSvc(repo);
    }

    public static ICarSvc CreateCarSvc()
    {
        var db = CreateDbContext();
        var repo = new CarRepo(db);
        return new CarSvc(repo);
    }

    public static IContributionSvc CreateContributionSvc()
    {
        var db = CreateDbContext();
        var repo = new ContributionRepo(db);
        return new ContributionSvc(repo);
    }

    public static IHousingSvc CreateHousingSvc()
    {
        var db = CreateDbContext();
        var repo = new HousingRepo(db);
        return new HousingSvc(repo);
    }

    public static IInvestmentSvc CreateInvestmentSvc()
    {
        var db = CreateDbContext();
        var repo = new InvestmentRepo(db);
        return new InvestmentSvc(repo);
    }

    public static IPaycheckSvc CreatePaycheckSvc()
    {
        var db = CreateDbContext();
        var repo = new PaycheckRepo(db);
        return new PaycheckSvc(repo);
    }

    public static ISideGigSvc CreateSideGigSvc()
    {
        var db = CreateDbContext();
        var repo = new SideGigRepo(db);
        return new SideGigSvc(repo);
    }

    public static ITransactionSvc CreateTransactionSvc()
    {
        var db = CreateDbContext();
        var repo = new TransactionRepo(db);
        return new TransactionSvc(repo);
    }
}
