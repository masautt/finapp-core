using Database.Transums.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Transums;

namespace Database.Transums;

public class TransumSubConfig : IEntityTypeConfiguration<TransumSubDto>
{
    public void Configure(EntityTypeBuilder<TransumSubDto> entity)
    {
        entity.ToTable(TransumViewConstants.TransumSub);

        // Primary key
        entity.HasKey(e => e.SubCategory);

        // Map inherited TransumCommonDto properties
        entity.ConfigureTransumCommon();

        // Map category-specific column (Category is already the PK)
        entity.Property(e => e.SubCategory).HasColumnName(TransumColumnConstants.SubCategory);
    }
}