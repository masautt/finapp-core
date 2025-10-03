using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Config;

public class CarConfig : IEntityTypeConfiguration<CarDto>
{
    public void Configure(EntityTypeBuilder<CarDto> entity)
    {
        entity.ToTable(TableConstants.Car);

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

        // Map Car-specific scalars
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
