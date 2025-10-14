using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Transums;

namespace Database.Transums.Shared;

public static class TransumCommonConfig
{
    public static void ConfigureTransumCommon<TEntity>(
        this EntityTypeBuilder<TEntity> entity
    ) where TEntity : TransumCommonDto
    {
        // Overall totals
        entity.Property(c => c.TotalAmount).HasColumnName(TransumColumnConstants.TotalAmount);
        entity.Property(c => c.TotalCount).HasColumnName(TransumColumnConstants.TotalCount);
        entity.Property(c => c.AverageAmount).HasColumnName(TransumColumnConstants.AverageAmount);

        // Ex / NonEx breakdowns
        entity.Property(c => c.TotalExAmount).HasColumnName(TransumColumnConstants.TotalExAmount);
        entity.Property(c => c.TotalExCount).HasColumnName(TransumColumnConstants.TotalExCount);
        entity.Property(c => c.AverageExAmount).HasColumnName(TransumColumnConstants.AverageExAmount);

        entity.Property(c => c.TotalNonExAmount).HasColumnName(TransumColumnConstants.TotalNonExAmount);
        entity.Property(c => c.TotalNonExCount).HasColumnName(TransumColumnConstants.TotalNonExCount);
        entity.Property(c => c.AverageNonExAmount).HasColumnName(TransumColumnConstants.AverageNonExAmount);

        // Necessity breakdowns
        entity.Property(c => c.TotalWantAmount).HasColumnName(TransumColumnConstants.TotalWantAmount);
        entity.Property(c => c.TotalWantCount).HasColumnName(TransumColumnConstants.TotalWantCount);
        entity.Property(c => c.AverageWantAmount).HasColumnName(TransumColumnConstants.AverageWantAmount);

        entity.Property(c => c.TotalNeedAmount).HasColumnName(TransumColumnConstants.TotalNeedAmount);
        entity.Property(c => c.TotalNeedCount).HasColumnName(TransumColumnConstants.TotalNeedCount);
        entity.Property(c => c.AverageNeedAmount).HasColumnName(TransumColumnConstants.AverageNeedAmount);

        // Recipient breakdowns
        entity.Property(c => c.TotalMarekAmount).HasColumnName(TransumColumnConstants.TotalMarekAmount);
        entity.Property(c => c.TotalMarekCount).HasColumnName(TransumColumnConstants.TotalMarekCount);
        entity.Property(c => c.AverageMarekAmount).HasColumnName(TransumColumnConstants.AverageMarekAmount);

        entity.Property(c => c.TotalLisaAmount).HasColumnName(TransumColumnConstants.TotalLisaAmount);
        entity.Property(c => c.TotalLisaCount).HasColumnName(TransumColumnConstants.TotalLisaCount);
        entity.Property(c => c.AverageLisaAmount).HasColumnName(TransumColumnConstants.AverageLisaAmount);

        entity.Property(c => c.TotalOtherAmount).HasColumnName(TransumColumnConstants.TotalOtherAmount);
        entity.Property(c => c.TotalOtherCount).HasColumnName(TransumColumnConstants.TotalOtherCount);
        entity.Property(c => c.AverageOtherAmount).HasColumnName(TransumColumnConstants.AverageOtherAmount);

        entity.Property(c => c.TotalPetAmount).HasColumnName(TransumColumnConstants.TotalPetAmount);
        entity.Property(c => c.TotalPetCount).HasColumnName(TransumColumnConstants.TotalPetCount);
        entity.Property(c => c.AveragePetAmount).HasColumnName(TransumColumnConstants.AveragePetAmount);
    }
}