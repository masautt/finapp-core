using Database.Tables.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables;

public class InvestmentConfig : IEntityTypeConfiguration<InvestmentDto>
{
    public void Configure(EntityTypeBuilder<InvestmentDto> entity)
    {
        entity.ToTable(TableConstants.Investments);

        // CommonId + CommonDto
        entity.ConfigureCommonEntity(e => e.Common);

        // DateRangeFields
        entity.ConfigureDateRange(e => e.Date);

        // Investment-specific fields
        entity.Property(e => e.BeginningBalance).HasColumnName(ColumnConstants.BeginningBalance);
        entity.Property(e => e.EndingBalance).HasColumnName(ColumnConstants.EndingBalance);
        entity.Property(e => e.ChangeInValue).HasColumnName(ColumnConstants.ChangeInValue);
        entity.Property(e => e.ChangeInPercentage).HasColumnName(ColumnConstants.ChangeInPercentage);
        entity.Property(e => e.Type).HasColumnName(ColumnConstants.Type);
    }
}