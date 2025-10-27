using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables.Shared;

namespace Database.Tables.Shared;

public static class CommonTableConfig
{
    public static void ConfigureCommonEntity<TEntity>(
        this EntityTypeBuilder<TEntity> entity,
        Expression<Func<TEntity, CommonTableDto>> commonExpression)
        where TEntity : class
    {
        // CommonId (shadow PK)
        entity.Property<string>(TableColumnConstants.CommonId)
            .HasColumnName(TableColumnConstants.Id);

        entity.HasKey(TableColumnConstants.CommonId);

        // CommonDto
        entity.OwnsOne(commonExpression!, common =>
        {
            common.Property(c => c.Id).HasColumnName(TableColumnConstants.Id);
            common.Property(c => c.Number).HasColumnName(TableColumnConstants.Number);
            common.Property(c => c.Comments).HasColumnName(TableColumnConstants.Comments);
        });
    }
}