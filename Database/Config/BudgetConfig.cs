using Database.Config.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Config;

public class BudgetConfig : IEntityTypeConfiguration<BudgetDto>
{
    public void Configure(EntityTypeBuilder<BudgetDto> entity)
    {
        entity.ToTable(TableConstants.Budgets);

        entity.ConfigureCommonId();
        entity.ConfigureCommon(e => e.Common);

        entity.Property(e => e.Category).HasColumnName(ColumnConstants.Category);
        entity.Property(e => e.Amount)
            .HasColumnName(ColumnConstants.Amount)
            .HasColumnType("decimal(18,2)");
    }
}
