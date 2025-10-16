using Database.Tables;
using Database.Transums;
using Microsoft.EntityFrameworkCore;
using Models.Tables;
using Models.Transums;

namespace Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<BudgetDto> Budgets { get; set; } = null!;

    public DbSet<SideGigDto> SideGigs { get; set; } = null!;

    public DbSet<HousingDto> Housings { get; set; } = null!;

    public DbSet<ContributionDto> Contributions { get; set; } = null!;

    public DbSet<CarDto> Cars { get; set; } = null!;

    public DbSet<PaycheckDto> Paychecks { get; set; } = null!;

    public DbSet<InvestmentDto> Investments { get; set; } = null!;

    public DbSet<TransactionDto> Transactions { get; set; } = null!;

    public DbSet<TransumBusDto> TransumBuses { get; set; } = null!;

    public DbSet<TransumCatDto> TransumCats { get; set; } = null!;

    public DbSet<TransumSubDto> TransumSubs { get; set; } = null!;

    public DbSet<TransumLocDto> TransumLocDtos { get; set; } = null!;


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

        modelBuilder.ApplyConfiguration(new TransumBusConfig());

        modelBuilder.ApplyConfiguration(new TransumCatConfig());

        modelBuilder.ApplyConfiguration(new TransumSubConfig());

        modelBuilder.ApplyConfiguration(new TransumLocConfig());
    }

}