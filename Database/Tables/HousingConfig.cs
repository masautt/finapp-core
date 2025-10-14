using Database.Tables.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables;

public class HousingConfig : IEntityTypeConfiguration<HousingDto>
{
    public void Configure(EntityTypeBuilder<HousingDto> entity)
    {
        entity.ToTable(TableConstants.Housing);

        // Common setup
        entity.ConfigureCommonEntity(e => e.Common);

        // DateRange setup
        entity.ConfigureDateRange(e => e.DateRange);

        // Housing-specific fields
        entity.Property(e => e.RentAmount).HasColumnName(ColumnConstants.RentAmount);
        entity.Property(e => e.RentDate).HasColumnName(ColumnConstants.RentDate);
        entity.Property(e => e.InsuranceAmount).HasColumnName(ColumnConstants.InsuranceAmount);
        entity.Property(e => e.InsuranceDate).HasColumnName(ColumnConstants.InsuranceDate);
        entity.Property(e => e.PetRent).HasColumnName(ColumnConstants.PetRent);
        entity.Property(e => e.Fees).HasColumnName(ColumnConstants.Fees);
        entity.Property(e => e.UtilitiesDate).HasColumnName(ColumnConstants.UtilitiesDate);
        entity.Property(e => e.Electricity).HasColumnName(ColumnConstants.Electricity);
        entity.Property(e => e.Water).HasColumnName(ColumnConstants.Water);
        entity.Property(e => e.Gas).HasColumnName(ColumnConstants.Gas);
        entity.Property(e => e.Wifi).HasColumnName(ColumnConstants.Wifi);
        entity.Property(e => e.CityServices).HasColumnName(ColumnConstants.CityServices);
        entity.Property(e => e.TotalUtilities).HasColumnName(ColumnConstants.TotalUtilities);
        entity.Property(e => e.TotalHousing).HasColumnName(ColumnConstants.TotalHousing);
    }
}