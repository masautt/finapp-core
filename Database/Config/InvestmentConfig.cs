using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Database.Config;

public class InvestmentConfig : IEntityTypeConfiguration<InvestmentDto>
{
    public void Configure(EntityTypeBuilder<InvestmentDto> entity)
    {
        entity.ToTable(TableConstants.Investments);

        // Define a shadow property as the primary key
        entity.Property<string>(ColumnConstants.CommonId)
            .HasColumnName(ColumnConstants.Id);

        entity.HasKey(ColumnConstants.CommonId); // shadow PK

        // Map CommonDto
        entity.OwnsOne(e => e.Common, common =>
        {
            common.Property(c => c.Id).HasColumnName(ColumnConstants.Id);
            common.Property(c => c.Number).HasColumnName(ColumnConstants.Number);
            common.Property(c => c.Comments).HasColumnName(ColumnConstants.Comments);
        });

        // Map DateRangeFields
        entity.OwnsOne(e => e.Date, date =>
        {
            date.Property(d => d.StartDate).HasColumnName(ColumnConstants.StartDate);
            date.Property(d => d.EndDate).HasColumnName(ColumnConstants.EndDate);
            date.Property(d => d.Month).HasColumnName(ColumnConstants.Month);
            date.Property(d => d.Year).HasColumnName(ColumnConstants.Year);
        });

        // Map Investment-specific scalars
        entity.Property(e => e.BeginningBalance).HasColumnName(ColumnConstants.BeginningBalance);
        entity.Property(e => e.EndingBalance).HasColumnName(ColumnConstants.EndingBalance);
        entity.Property(e => e.ChangeInValue).HasColumnName(ColumnConstants.ChangeInValue);
        entity.Property(e => e.ChangeInPercentage).HasColumnName(ColumnConstants.ChangeInPercentage);
        entity.Property(e => e.Type).HasColumnName(ColumnConstants.Type);
    }

}