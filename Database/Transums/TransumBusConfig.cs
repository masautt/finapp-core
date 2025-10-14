using Database.Transums.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Transums;

namespace Database.Transums;

public class TransumBusConfig : IEntityTypeConfiguration<TransumBusDto>
{
    public void Configure(EntityTypeBuilder<TransumBusDto> entity)
    {
        entity.ToTable(TransumViewConstants.TransumBusiness);

        // Primary key
        entity.HasKey(e => e.Business);

        // Map inherited TransumCommonDto properties
        entity.ConfigureTransumCommon();

        // Map business-specific column (Business is already the PK)
        entity.Property(e => e.Business).HasColumnName(TransumColumnConstants.Business);
    }
}
