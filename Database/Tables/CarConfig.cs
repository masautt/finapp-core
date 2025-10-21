using Database.Tables.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables;

public class CarConfig : IEntityTypeConfiguration<CarDto>
{
    public void Configure(EntityTypeBuilder<CarDto> entity)
    {
        entity.ToTable(TableConstants.Car);

        // Use shared config for CommonId + CommonDto
        entity.ConfigureCommonEntity(e => e.Common);

        // Map DateRange
        entity.OwnsOne(e => e.DateRange, date =>
        {
            date.Property(d => d.StartDate).HasColumnName(ColumnConstants.StartDate);
            date.Property(d => d.EndDate).HasColumnName(ColumnConstants.EndDate);
            date.Property(d => d.Month).HasColumnName(ColumnConstants.Month);
            date.Property(d => d.Year).HasColumnName(ColumnConstants.Year);
        });

        // Car-specific fields
        entity.Property(e => e.PaymentDate).HasColumnName(ColumnConstants.PaymentDate);
        entity.Property(e => e.PaymentAmount).HasColumnName(ColumnConstants.PaymentAmount);
        entity.Property(e => e.Principal).HasColumnName(ColumnConstants.Principal);
        entity.Property(e => e.Interest).HasColumnName(ColumnConstants.Interest);
        entity.Property(e => e.Owed).HasColumnName(ColumnConstants.Owed);
        entity.Property(e => e.InsuranceAmount).HasColumnName(ColumnConstants.InsuranceAmount);
        entity.Property(e => e.InsuranceDate).HasColumnName(ColumnConstants.InsuranceDate);
        entity.Property(e => e.StartMiles).HasColumnName(ColumnConstants.StartMiles);
        entity.Property(e => e.MilesAdded).HasColumnName(ColumnConstants.MilesAdded);
        entity.Property(e => e.MilesDate).HasColumnName(ColumnConstants.MilesDate);
    }
}