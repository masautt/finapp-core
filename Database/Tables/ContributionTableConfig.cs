using Database.Tables.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables;

public class ContributionTableConfig : IEntityTypeConfiguration<ContributionTableDto>
{
    public void Configure(EntityTypeBuilder<ContributionTableDto> entity)
    {
        entity.ToTable(TableConstants.Contributions);

        // Common setup
        entity.ConfigureCommonEntity(e => e.Common);

        // Date setup (ExactDateFields)
        entity.ConfigureExactDate(e => e.Date);

        // Contribution-specific fields
        entity.Property(e => e.Amount).HasColumnName(TableColumnConstants.Amount);
        entity.Property(e => e.Exclude).HasColumnName(TableColumnConstants.Exclude);
        entity.Property(e => e.Account).HasColumnName(TableColumnConstants.Account);
    }
}