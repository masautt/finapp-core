using Database.Tables.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables;

public class SideGigTableConfig : IEntityTypeConfiguration<SideGigTableDto>
{
    public void Configure(EntityTypeBuilder<SideGigTableDto> entity)
    {
        entity.ToTable(TableConstants.SideGigs);

        // CommonId + CommonDto
        entity.ConfigureCommonEntity(e => e.Common);

        // DateRangeFields
        entity.ConfigureDateRange(e => e.DateRange);

        // SideGig-specific properties
        entity.Property(e => e.HoursWorked).HasColumnName(TableColumnConstants.HoursWorked);
        entity.Property(e => e.AmountPaid).HasColumnName(TableColumnConstants.AmountPaid);
        entity.Property(e => e.Company).HasColumnName(TableColumnConstants.Company);
    }
}