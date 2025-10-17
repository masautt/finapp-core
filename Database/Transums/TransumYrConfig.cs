using Database.Transums.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Transums;

namespace Database.Transums;

public class TransumYrConfig : IEntityTypeConfiguration<TransumYrDto>
{
    public void Configure(EntityTypeBuilder<TransumYrDto> entity)
    {
        entity.ToTable(TransumViewConstants.TransumYr);

        // Primary key
        entity.HasKey(e => e.Year);

        // Map inherited TransumCommonDto properties
        entity.ConfigureTransumCommon();

        // Map category-specific column (Year is already the PK)
        entity.Property(e => e.Year).HasColumnName(TransumColumnConstants.Year);
    }
}