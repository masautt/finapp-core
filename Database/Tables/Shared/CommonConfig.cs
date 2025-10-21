using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables.Shared;

public static class CommonConfig
{
    public static void ConfigureCommonEntity<TEntity>(
        this EntityTypeBuilder<TEntity> entity,
        Expression<Func<TEntity, CommonDto>> commonExpression)
        where TEntity : class
    {
        // CommonId (shadow PK)
        entity.Property<string>(ColumnConstants.CommonId)
            .HasColumnName(ColumnConstants.Id);

        entity.HasKey(ColumnConstants.CommonId);

        // CommonDto
        entity.OwnsOne(commonExpression!, common =>
        {
            common.Property(c => c.Id).HasColumnName(ColumnConstants.Id);
            common.Property(c => c.Number).HasColumnName(ColumnConstants.Number);
            common.Property(c => c.Comments).HasColumnName(ColumnConstants.Comments);
        });
    }
}