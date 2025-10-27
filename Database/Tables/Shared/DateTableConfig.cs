using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;
using Models.Tables.Shared;

namespace Database.Tables.Shared;

public static class DateTableConfig
{
    public static void ConfigureExactDate<TEntity>(
        this EntityTypeBuilder<TEntity> entity,
        Expression<Func<TEntity, ExactDateFields>> dateExpression)
        where TEntity : class
    {
        entity.OwnsOne(dateExpression!, date =>
        {
            date.Property(d => d.Year).HasColumnName(TableColumnConstants.Year);
            date.Property(d => d.Month).HasColumnName(TableColumnConstants.Month);
            date.Property(d => d.Day).HasColumnName(TableColumnConstants.Day);
            date.Property(d => d.Weekday).HasColumnName(TableColumnConstants.Weekday);
            date.Property(d => d.Date).HasColumnName(TableColumnConstants.Date);
        });
    }

    public static void ConfigureDateRange<TEntity>(
        this EntityTypeBuilder<TEntity> entity,
        Expression<Func<TEntity, DateRangeFields>> dateExpression)
        where TEntity : class
    {
        entity.OwnsOne(dateExpression!, date =>
        {
            date.Property(d => d.StartDate).HasColumnName(TableColumnConstants.StartDate);
            date.Property(d => d.EndDate).HasColumnName(TableColumnConstants.EndDate);
            date.Property(d => d.Month).HasColumnName(TableColumnConstants.Month);
            date.Property(d => d.Year).HasColumnName(TableColumnConstants.Year);
        });
    }
}