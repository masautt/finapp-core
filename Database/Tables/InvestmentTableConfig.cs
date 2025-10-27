using Database.Tables.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables;

public class InvestmentTableConfig : IEntityTypeConfiguration<InvestmentTableDto>
{
    public void Configure(EntityTypeBuilder<InvestmentTableDto> entity)
    {
        entity.ToTable(TableConstants.Investments);

        // CommonId + CommonDto
        entity.ConfigureCommonEntity(e => e.Common);

        // DateRangeFields
        entity.ConfigureDateRange(e => e.Date);

        // Investment-specific fields
        entity.Property(e => e.BeginningBalance).HasColumnName(TableColumnConstants.BeginningBalance);
        entity.Property(e => e.EndingBalance).HasColumnName(TableColumnConstants.EndingBalance);
        entity.Property(e => e.ChangeInValue).HasColumnName(TableColumnConstants.ChangeInValue);
        entity.Property(e => e.ChangeInPercentage).HasColumnName(TableColumnConstants.ChangeInPercentage);
        entity.Property(e => e.Type).HasColumnName(TableColumnConstants.Type);
    }
}