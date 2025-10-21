using Database.Tables.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables;

public class ContributionConfig : IEntityTypeConfiguration<ContributionDto>
{
    public void Configure(EntityTypeBuilder<ContributionDto> entity)
    {
        entity.ToTable(TableConstants.Contributions);

        // Common setup
        entity.ConfigureCommonEntity(e => e.Common);

        // Date setup (ExactDateFields)
        entity.ConfigureExactDate(e => e.Date);

        // Contribution-specific fields
        entity.Property(e => e.Amount).HasColumnName(ColumnConstants.Amount);
        entity.Property(e => e.Exclude).HasColumnName(ColumnConstants.Exclude);
        entity.Property(e => e.Account).HasColumnName(ColumnConstants.Account);
    }
}