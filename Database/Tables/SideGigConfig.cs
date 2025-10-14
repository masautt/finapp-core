using Database.Tables.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables;

public class SideGigConfig : IEntityTypeConfiguration<SideGigDto>
{
    public void Configure(EntityTypeBuilder<SideGigDto> entity)
    {
        entity.ToTable(TableConstants.SideGigs);

        // CommonId + CommonDto
        entity.ConfigureCommonEntity(e => e.Common);

        // DateRangeFields
        entity.ConfigureDateRange(e => e.DateRange);

        // SideGig-specific properties
        entity.Property(e => e.HoursWorked).HasColumnName(ColumnConstants.HoursWorked);
        entity.Property(e => e.AmountPaid).HasColumnName(ColumnConstants.AmountPaid);
        entity.Property(e => e.Company).HasColumnName(ColumnConstants.Company);
    }
}