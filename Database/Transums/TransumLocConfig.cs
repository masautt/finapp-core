using Database.Transums.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Transums;

namespace Database.Transums;

public class TransumLocConfig : IEntityTypeConfiguration<TransumLocDto>
{
    public void Configure(EntityTypeBuilder<TransumLocDto> entity)
    {
        entity.ToTable(TransumViewConstants.TransumLoc);

        // Composite primary key
        entity.HasKey(e => new { e.City, e.State });

        // Map inherited TransumCommonDto properties
        entity.ConfigureTransumCommon();

        // Map location-specific columns
        entity.Property(e => e.City).HasColumnName(TransumColumnConstants.City);
        entity.Property(e => e.State).HasColumnName(TransumColumnConstants.State);
    }
}