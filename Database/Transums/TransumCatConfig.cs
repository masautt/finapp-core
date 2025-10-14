using Database.Transums.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Transums;

namespace Database.Transums;

public class TransumCatConfig : IEntityTypeConfiguration<TransumCatDto>
{
    public void Configure(EntityTypeBuilder<TransumCatDto> entity)
    {
        entity.ToTable(TransumViewConstants.TransumCategory);

        // Primary key
        entity.HasKey(e => e.Category);

        // Map inherited TransumCommonDto properties
        entity.ConfigureTransumCommon();

        // Map category-specific column (Category is already the PK)
        entity.Property(e => e.Category).HasColumnName(TransumColumnConstants.Category);
    }
}