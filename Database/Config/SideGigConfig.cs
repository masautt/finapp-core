using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Config;

public class SideGigConfig : IEntityTypeConfiguration<SideGigDto>
{
    public void Configure(EntityTypeBuilder<SideGigDto> entity)
    {
        entity.ToTable(TableConstants.SideGigs);

        // Define a shadow property as the primary key
        entity.Property<string>(ColumnConstants.CommonId)
            .HasColumnName(ColumnConstants.Id);

        entity.HasKey(ColumnConstants.CommonId); // shadow property as PK

        // Map CommonDto
        entity.OwnsOne(e => e.Common, common =>
        {
            common.Property(c => c.Id)
                .HasColumnName(ColumnConstants.Id); // same column as shadow PK
            common.Property(c => c.Number)
                .HasColumnName(ColumnConstants.Number);
            common.Property(c => c.Comments)
                .HasColumnName(ColumnConstants.Comments);
        });

        // Map DateRangeFields
        entity.OwnsOne(e => e.DateRange, date =>
        {
            date.Property(d => d.StartDate).HasColumnName(ColumnConstants.StartDate);
            date.Property(d => d.EndDate).HasColumnName(ColumnConstants.EndDate);
            date.Property(d => d.Month).HasColumnName(ColumnConstants.Month);
            date.Property(d => d.Year).HasColumnName(ColumnConstants.Year);
        });

        // SideGig-specific properties
        entity.Property(e => e.HoursWorked).HasColumnName(ColumnConstants.HoursWorked);
        entity.Property(e => e.AmountPaid).HasColumnName(ColumnConstants.AmountPaid);
        entity.Property(e => e.Company).HasColumnName(ColumnConstants.Company);
    }
}