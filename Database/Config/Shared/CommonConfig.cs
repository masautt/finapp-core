using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Config.Shared;

public static class CommonConfig
{
    // Configure shadow PK
    public static void ConfigureCommonId<TEntity>(this EntityTypeBuilder<TEntity> entity)
        where TEntity : class
    {
        entity.Property<string>(e => EF.Property<string>(e, "CommonId"))
            .HasColumnName(ColumnConstants.Id);
        entity.HasKey("CommonId");
    }

    // Configure CommonDto owned type
    public static void ConfigureCommon<TEntity>(this EntityTypeBuilder<TEntity> entity,
        Expression<Func<TEntity, CommonDto>> commonExpression)
        where TEntity : class
    {
        entity.OwnsOne(commonExpression!, common =>
        {
            common.Property(c => c.Id).HasColumnName(ColumnConstants.Id);
            common.Property(c => c.Number).HasColumnName(ColumnConstants.Number);
            common.Property(c => c.Comments).HasColumnName(ColumnConstants.Comments);
        });
    }
}