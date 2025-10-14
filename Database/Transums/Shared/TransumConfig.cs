using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Transums;

namespace Database.Transums.Shared;

public static class TransumCommonConfig
{
    public static void ConfigureTransumCommon<TEntity>(
        this EntityTypeBuilder<TEntity> entity,
        Expression<Func<TEntity, TransumCommonDto>> commonExpression)
        where TEntity : class
    {
        entity.OwnsOne(commonExpression!, common =>
        {
            // Overall totals
            common.Property(c => c.TotalAmount).HasColumnName(TransumColumnConstants.TotalAmount);
            common.Property(c => c.TotalCount).HasColumnName(TransumColumnConstants.TotalCount);
            common.Property(c => c.AverageAmount).HasColumnName(TransumColumnConstants.AverageAmount);

            // Ex / NonEx breakdowns
            common.Property(c => c.TotalExAmount).HasColumnName(TransumColumnConstants.TotalExAmount);
            common.Property(c => c.TotalExCount).HasColumnName(TransumColumnConstants.TotalExCount);
            common.Property(c => c.AverageExAmount).HasColumnName(TransumColumnConstants.AverageExAmount);

            common.Property(c => c.TotalNonExAmount).HasColumnName(TransumColumnConstants.TotalNonExAmount);
            common.Property(c => c.TotalNonExCount).HasColumnName(TransumColumnConstants.TotalNonExCount);
            common.Property(c => c.AverageNonExAmount).HasColumnName(TransumColumnConstants.AverageNonExAmount);

            // Necessity breakdowns
            common.Property(c => c.TotalWantAmount).HasColumnName(TransumColumnConstants.TotalWantAmount);
            common.Property(c => c.TotalWantCount).HasColumnName(TransumColumnConstants.TotalWantCount);
            common.Property(c => c.AverageWantAmount).HasColumnName(TransumColumnConstants.AverageWantAmount);

            common.Property(c => c.TotalNeedAmount).HasColumnName(TransumColumnConstants.TotalNeedAmount);
            common.Property(c => c.TotalNeedCount).HasColumnName(TransumColumnConstants.TotalNeedCount);
            common.Property(c => c.AverageNeedAmount).HasColumnName(TransumColumnConstants.AverageNeedAmount);

            // Recipient breakdowns
            common.Property(c => c.TotalMarekAmount).HasColumnName(TransumColumnConstants.TotalMarekAmount);
            common.Property(c => c.TotalMarekCount).HasColumnName(TransumColumnConstants.TotalMarekCount);
            common.Property(c => c.AverageMarekAmount).HasColumnName(TransumColumnConstants.AverageMarekAmount);

            common.Property(c => c.TotalLisaAmount).HasColumnName(TransumColumnConstants.TotalLisaAmount);
            common.Property(c => c.TotalLisaCount).HasColumnName(TransumColumnConstants.TotalLisaCount);
            common.Property(c => c.AverageLisaAmount).HasColumnName(TransumColumnConstants.AverageLisaAmount);

            common.Property(c => c.TotalOtherAmount).HasColumnName(TransumColumnConstants.TotalOtherAmount);
            common.Property(c => c.TotalOtherCount).HasColumnName(TransumColumnConstants.TotalOtherCount);
            common.Property(c => c.AverageOtherAmount).HasColumnName(TransumColumnConstants.AverageOtherAmount);

            common.Property(c => c.TotalPetAmount).HasColumnName(TransumColumnConstants.TotalPetAmount);
            common.Property(c => c.TotalPetCount).HasColumnName(TransumColumnConstants.TotalPetCount);
            common.Property(c => c.AveragePetAmount).HasColumnName(TransumColumnConstants.AveragePetAmount);
        });
    }
}
