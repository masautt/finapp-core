using Database.Tables;
using Database.Transums;
using Microsoft.EntityFrameworkCore;
using Models.Tables;
using Models.Transums;

namespace Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BudgetConfig());

        modelBuilder.ApplyConfiguration(new SideGigConfig());

        modelBuilder.ApplyConfiguration(new HousingConfig());

        modelBuilder.ApplyConfiguration(new ContributionConfig());

        modelBuilder.ApplyConfiguration(new CarConfig());

        modelBuilder.ApplyConfiguration(new PaycheckConfig());

        modelBuilder.ApplyConfiguration(new InvestmentConfig());

        modelBuilder.ApplyConfiguration(new TransactionConfig());

        modelBuilder.ConfigureTransumEntities();
    }
}