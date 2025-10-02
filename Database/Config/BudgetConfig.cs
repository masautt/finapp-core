using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Config;

public class BudgetConfig : IEntityTypeConfiguration<BudgetDto>
{
    public void Configure(EntityTypeBuilder<BudgetDto> entity)
    {
        entity.ToTable(TableConstants.Budgets);

        // Define a shadow property as the primary key
        entity.Property<string>(ColumnConstants.CommonId) // shadow property
            .HasColumnName(ColumnConstants.Id);

        entity.HasKey(ColumnConstants.CommonId); // use shadow property as PK

        // Map the CommonDto
        entity.OwnsOne(e => e.Common, common =>
        {
            common.Property(c => c.Id)
                .HasColumnName(ColumnConstants.Id); // maps to the same column
            common.Property(c => c.Number)
                .HasColumnName(ColumnConstants.Number);
            common.Property(c => c.Comments)
                .HasColumnName(ColumnConstants.Comments);
        });

        // Map Budget-specific properties
        entity.Property(e => e.Category)
            .HasColumnName(ColumnConstants.Category);
        entity.Property(e => e.Amount)
            .HasColumnName(ColumnConstants.Amount)
            .HasColumnType("decimal(18,2)");
    }
}