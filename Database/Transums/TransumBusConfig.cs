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

        // Map TransumCommonDto owned type
        entity.ConfigureTransumCommon(e => e);

        // Map Business-specific column
        entity.Property(e => e.Business).HasColumnName(TransumColumnConstants.Business);
    }
}
