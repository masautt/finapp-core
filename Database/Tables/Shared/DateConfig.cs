using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Tables;

namespace Database.Tables.Shared;

public static class DateConfig
{
    public static void ConfigureExactDate<TEntity>(
        this EntityTypeBuilder<TEntity> entity,
        Expression<Func<TEntity, ExactDateFields>> dateExpression)
        where TEntity : class
    {
        entity.OwnsOne(dateExpression!, date =>
        {
            date.Property(d => d.Year).HasColumnName(ColumnConstants.Year);
            date.Property(d => d.Month).HasColumnName(ColumnConstants.Month);
            date.Property(d => d.Day).HasColumnName(ColumnConstants.Day);
            date.Property(d => d.Weekday).HasColumnName(ColumnConstants.Weekday);
            date.Property(d => d.Date).HasColumnName(ColumnConstants.Date);
        });
    }

    public static void ConfigureDateRange<TEntity>(
        this EntityTypeBuilder<TEntity> entity,
        Expression<Func<TEntity, DateRangeFields>> dateExpression)
        where TEntity : class
    {
        entity.OwnsOne(dateExpression!, date =>
        {
            date.Property(d => d.StartDate).HasColumnName(ColumnConstants.StartDate);
            date.Property(d => d.EndDate).HasColumnName(ColumnConstants.EndDate);
            date.Property(d => d.Month).HasColumnName(ColumnConstants.Month);
            date.Property(d => d.Year).HasColumnName(ColumnConstants.Year);
        });
    }
}