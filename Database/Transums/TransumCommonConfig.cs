using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Transums;

namespace Database.Transums;

public static class TransumCommonConfig
{
    public static void ConfigureTransumCommon<TEntity>(
        this EntityTypeBuilder<TEntity> entity
    ) where TEntity : TransumCommonDto
    {
        // Overall totals
        entity.Property(c => c.TotalAmount).HasColumnName(TransumConstants.TotalAmount);
        entity.Property(c => c.TotalCount).HasColumnName(TransumConstants.TotalCount);
        entity.Property(c => c.AverageAmount).HasColumnName(TransumConstants.AverageAmount);

        // Ex / NonEx breakdowns
        entity.Property(c => c.TotalExAmount).HasColumnName(TransumConstants.TotalExAmount);
        entity.Property(c => c.TotalExCount).HasColumnName(TransumConstants.TotalExCount);
        entity.Property(c => c.AverageExAmount).HasColumnName(TransumConstants.AverageExAmount);

        entity.Property(c => c.TotalNonExAmount).HasColumnName(TransumConstants.TotalNonExAmount);
        entity.Property(c => c.TotalNonExCount).HasColumnName(TransumConstants.TotalNonExCount);
        entity.Property(c => c.AverageNonExAmount).HasColumnName(TransumConstants.AverageNonExAmount);

        // Necessity breakdowns
        entity.Property(c => c.TotalWantAmount).HasColumnName(TransumConstants.TotalWantAmount);
        entity.Property(c => c.TotalWantCount).HasColumnName(TransumConstants.TotalWantCount);
        entity.Property(c => c.AverageWantAmount).HasColumnName(TransumConstants.AverageWantAmount);

        entity.Property(c => c.TotalNeedAmount).HasColumnName(TransumConstants.TotalNeedAmount);
        entity.Property(c => c.TotalNeedCount).HasColumnName(TransumConstants.TotalNeedCount);
        entity.Property(c => c.AverageNeedAmount).HasColumnName(TransumConstants.AverageNeedAmount);

        // Recipient breakdowns
        entity.Property(c => c.TotalMarekAmount).HasColumnName(TransumConstants.TotalMarekAmount);
        entity.Property(c => c.TotalMarekCount).HasColumnName(TransumConstants.TotalMarekCount);
        entity.Property(c => c.AverageMarekAmount).HasColumnName(TransumConstants.AverageMarekAmount);

        entity.Property(c => c.TotalLisaAmount).HasColumnName(TransumConstants.TotalLisaAmount);
        entity.Property(c => c.TotalLisaCount).HasColumnName(TransumConstants.TotalLisaCount);
        entity.Property(c => c.AverageLisaAmount).HasColumnName(TransumConstants.AverageLisaAmount);

        entity.Property(c => c.TotalOtherAmount).HasColumnName(TransumConstants.TotalOtherAmount);
        entity.Property(c => c.TotalOtherCount).HasColumnName(TransumConstants.TotalOtherCount);
        entity.Property(c => c.AverageOtherAmount).HasColumnName(TransumConstants.AverageOtherAmount);

        entity.Property(c => c.TotalPetAmount).HasColumnName(TransumConstants.TotalPetAmount);
        entity.Property(c => c.TotalPetCount).HasColumnName(TransumConstants.TotalPetCount);
        entity.Property(c => c.AveragePetAmount).HasColumnName(TransumConstants.AveragePetAmount);
    }
}