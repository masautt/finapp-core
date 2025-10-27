using Database.Tables.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables;

public class HousingTableConfig : IEntityTypeConfiguration<HousingTableDto>
{
    public void Configure(EntityTypeBuilder<HousingTableDto> entity)
    {
        entity.ToTable(TableConstants.Housing);

        // Common setup
        entity.ConfigureCommonEntity(e => e.Common);

        // DateRange setup
        entity.ConfigureDateRange(e => e.DateRange);

        // Housing-specific fields
        entity.Property(e => e.RentAmount).HasColumnName(TableColumnConstants.RentAmount);
        entity.Property(e => e.RentDate).HasColumnName(TableColumnConstants.RentDate);
        entity.Property(e => e.InsuranceAmount).HasColumnName(TableColumnConstants.InsuranceAmount);
        entity.Property(e => e.InsuranceDate).HasColumnName(TableColumnConstants.InsuranceDate);
        entity.Property(e => e.PetRent).HasColumnName(TableColumnConstants.PetRent);
        entity.Property(e => e.Fees).HasColumnName(TableColumnConstants.Fees);
        entity.Property(e => e.UtilitiesDate).HasColumnName(TableColumnConstants.UtilitiesDate);
        entity.Property(e => e.Electricity).HasColumnName(TableColumnConstants.Electricity);
        entity.Property(e => e.Water).HasColumnName(TableColumnConstants.Water);
        entity.Property(e => e.Gas).HasColumnName(TableColumnConstants.Gas);
        entity.Property(e => e.Wifi).HasColumnName(TableColumnConstants.Wifi);
        entity.Property(e => e.CityServices).HasColumnName(TableColumnConstants.CityServices);
        entity.Property(e => e.TotalUtilities).HasColumnName(TableColumnConstants.TotalUtilities);
        entity.Property(e => e.TotalHousing).HasColumnName(TableColumnConstants.TotalHousing);
    }
}