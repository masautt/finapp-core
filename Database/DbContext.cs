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

        modelBuilder.ApplyConfiguration(new BudgetTableConfig());

        modelBuilder.ApplyConfiguration(new SideGigTableConfig());

        modelBuilder.ApplyConfiguration(new HousingTableConfig());

        modelBuilder.ApplyConfiguration(new ContributionTableConfig());

        modelBuilder.ApplyConfiguration(new CarTableConfig());

        modelBuilder.ApplyConfiguration(new PaycheckTableConfig());

        modelBuilder.ApplyConfiguration(new InvestmentTableConfig());

        modelBuilder.ApplyConfiguration(new TransactionTableConfig());

        modelBuilder.ConfigureTransumEntities();
    }
}