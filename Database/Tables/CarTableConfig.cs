using Database.Tables.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables;

public class CarTableConfig : IEntityTypeConfiguration<CarTableDto>
{
    public void Configure(EntityTypeBuilder<CarTableDto> entity)
    {
        entity.ToTable(TableConstants.Car);

        // Use shared config for CommonId + CommonDto
        entity.ConfigureCommonEntity(e => e.Common);

        // Map DateRange
        entity.OwnsOne(e => e.DateRange, date =>
        {
            date.Property(d => d.StartDate).HasColumnName(TableColumnConstants.StartDate);
            date.Property(d => d.EndDate).HasColumnName(TableColumnConstants.EndDate);
            date.Property(d => d.Month).HasColumnName(TableColumnConstants.Month);
            date.Property(d => d.Year).HasColumnName(TableColumnConstants.Year);
        });

        // Car-specific fields
        entity.Property(e => e.PaymentDate).HasColumnName(TableColumnConstants.PaymentDate);
        entity.Property(e => e.PaymentAmount).HasColumnName(TableColumnConstants.PaymentAmount);
        entity.Property(e => e.Principal).HasColumnName(TableColumnConstants.Principal);
        entity.Property(e => e.Interest).HasColumnName(TableColumnConstants.Interest);
        entity.Property(e => e.Owed).HasColumnName(TableColumnConstants.Owed);
        entity.Property(e => e.InsuranceAmount).HasColumnName(TableColumnConstants.InsuranceAmount);
        entity.Property(e => e.InsuranceDate).HasColumnName(TableColumnConstants.InsuranceDate);
        entity.Property(e => e.StartMiles).HasColumnName(TableColumnConstants.StartMiles);
        entity.Property(e => e.MilesAdded).HasColumnName(TableColumnConstants.MilesAdded);
        entity.Property(e => e.MilesDate).HasColumnName(TableColumnConstants.MilesDate);
    }
}