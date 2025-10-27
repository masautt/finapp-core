using Database.Tables.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables;

public class BudgetTableConfig : IEntityTypeConfiguration<BudgetTableDto>
{
    public void Configure(EntityTypeBuilder<BudgetTableDto> entity)
    {
        entity.ToTable(TableConstants.Budgets);

        // Single unified config for CommonId + CommonDto
        entity.ConfigureCommonEntity(e => e.Common);

        // Budget-specific fields
        entity.Property(e => e.Category).HasColumnName(TableColumnConstants.Category);
        entity.Property(e => e.Amount).HasColumnName(TableColumnConstants.Amount);
    }
}