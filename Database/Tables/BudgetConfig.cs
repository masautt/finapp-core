using Database.Tables.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables;

public class BudgetConfig : IEntityTypeConfiguration<BudgetDto>
{
    public void Configure(EntityTypeBuilder<BudgetDto> entity)
    {
        entity.ToTable(TableConstants.Budgets);

        // Single unified config for CommonId + CommonDto
        entity.ConfigureCommonEntity(e => e.Common);

        // Budget-specific fields
        entity.Property(e => e.Category).HasColumnName(ColumnConstants.Category);
        entity.Property(e => e.Amount).HasColumnName(ColumnConstants.Amount);
    }
}