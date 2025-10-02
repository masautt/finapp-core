using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Config;

public class ContributionConfig : IEntityTypeConfiguration<ContributionDto>
{
    public void Configure(EntityTypeBuilder<ContributionDto> entity)
    {
        entity.ToTable(TableConstants.Contributions);

        entity.Property<string>(ColumnConstants.CommonId)
            .HasColumnName(ColumnConstants.Id);

        entity.HasKey(ColumnConstants.CommonId);

        // Map CommonDto
        entity.OwnsOne(e => e.Common, common =>
        {
            common.Property(c => c.Id).HasColumnName(ColumnConstants.Id);
            common.Property(c => c.Number).HasColumnName(ColumnConstants.Number);
            common.Property(c => c.Comments).HasColumnName(ColumnConstants.Comments);
        });

        // Map ExactDateFields
        entity.OwnsOne(e => e.Date, date =>
        {
            date.Property(d => d.Year).HasColumnName(ColumnConstants.Year);
            date.Property(d => d.Month).HasColumnName(ColumnConstants.Month);
            date.Property(d => d.Day).HasColumnName(ColumnConstants.Day);
            date.Property(d => d.Weekday).HasColumnName(ColumnConstants.Weekday);
            date.Property(d => d.Date).HasColumnName(ColumnConstants.Date);
        });

        // Contribution-specific fields
        entity.Property(e => e.Amount).HasColumnName(ColumnConstants.Amount);
        entity.Property(e => e.Exclude).HasColumnName(ColumnConstants.Exclude);
        entity.Property(e => e.Account).HasColumnName(ColumnConstants.Account);
    }
}