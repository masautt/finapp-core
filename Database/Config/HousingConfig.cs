using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Database.Config;

public class HousingConfig : IEntityTypeConfiguration<HousingDto>
{
    public void Configure(EntityTypeBuilder<HousingDto> entity)
    {
        entity.ToTable(TableConstants.Housing);

        // Define a shadow property as the primary key
        entity.Property<string>(ColumnConstants.CommonId)
            .HasColumnName(ColumnConstants.Id);

        entity.HasKey(ColumnConstants.CommonId); // shadow PK

        // Map CommonDto
        entity.OwnsOne(e => e.Common, common =>
        {
            common.Property(c => c.Id).HasColumnName(ColumnConstants.Id);
            common.Property(c => c.Number).HasColumnName(ColumnConstants.Number);
            common.Property(c => c.Comments).HasColumnName(ColumnConstants.Comments);
        });

        // Map DateRangeFields
        entity.OwnsOne(e => e.DateRange, date =>
        {
            date.Property(d => d.StartDate).HasColumnName(ColumnConstants.StartDate);
            date.Property(d => d.EndDate).HasColumnName(ColumnConstants.EndDate);
            date.Property(d => d.Month).HasColumnName(ColumnConstants.Month);
            date.Property(d => d.Year).HasColumnName(ColumnConstants.Year);
        });

        // Map Housing-specific scalars
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
