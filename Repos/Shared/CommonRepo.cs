using Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repos.Shared;

public class CommonRepo(AppDbContext dbContext)
{
    public async Task<TEntity?> FetchById<TEntity>(string id) where TEntity : class
        => await dbContext.Set<TEntity>().FindAsync(id);

    public async Task<TEntity?> FetchByNumber<TEntity>(int number) where TEntity : class
    {
        IQueryable<TEntity> query = dbContext.Set<TEntity>();

        var lambda = BuildCommonNumberPredicate<TEntity>(number);
        return await query.Where(lambda).FirstOrDefaultAsync();
    }

    public async Task<int> FetchTotalCount<TEntity>() where TEntity : class
        => await dbContext.Set<TEntity>().CountAsync();

    public async Task<TEntity?> FetchLatestRecord<TEntity>(
        Expression<Func<TEntity, bool>>? predicate = null
    ) where TEntity : class
    {
        IQueryable<TEntity> query = dbContext.Set<TEntity>();
        if (predicate != null)
            query = query.Where(predicate);

        var numberSelector = BuildCommonNumberSelector<TEntity>();
        return await query.OrderByDescending(numberSelector).FirstOrDefaultAsync();
    }

    public async Task<TEntity?> FetchOldestRecord<TEntity>(
        Expression<Func<TEntity, bool>>? predicate = null
    ) where TEntity : class
    {
        IQueryable<TEntity> query = dbContext.Set<TEntity>();
        if (predicate != null)
            query = query.Where(predicate);

        var numberSelector = BuildCommonNumberSelector<TEntity>();
        return await query.OrderBy(numberSelector).FirstOrDefaultAsync();
    }

    public async Task<TEntity?> FetchRandomRecord<TEntity>(
        Expression<Func<TEntity, bool>>? predicate = null
    ) where TEntity : class
    {
        IQueryable<TEntity> query = dbContext.Set<TEntity>();
        if (predicate != null)
            query = query.Where(predicate);

        return await query.OrderBy(x => Guid.NewGuid()).FirstOrDefaultAsync();
    }

    public async Task<List<TEntity>> FetchByCustom<TEntity>(
        params (Expression<Func<TEntity, object>> selector, object value)[]? filters
    ) where TEntity : class
    {
        IQueryable<TEntity> query = dbContext.Set<TEntity>();

        if (filters == null || filters.Length == 0)
            return await query.ToListAsync();

        var parameter = Expression.Parameter(typeof(TEntity), "x");
        Expression? combined = null;

        foreach (var (selector, value) in filters)
        {
            // Get the property expression from the selector
            var property = selector.Body;

            // If the expression is a Convert (e.g., object cast), unwrap it
            if (property is UnaryExpression { NodeType: ExpressionType.Convert } unary)
                property = unary.Operand;

            // Replace parameter in the selector with our new parameter
            property = new ParameterReplacer(selector.Parameters[0], parameter).Visit(property)!;

            var constant = Expression.Constant(value, property.Type);
            var equal = Expression.Equal(property, constant);

            combined = combined == null ? equal : Expression.AndAlso(combined, equal);
        }

        var lambda = Expression.Lambda<Func<TEntity, bool>>(combined!, parameter);
        return await query.Where(lambda).ToListAsync();
    }

    public async Task<List<TValue>> FetchDistinct<TEntity, TValue>(
        Expression<Func<TEntity, TValue>> selector,
        params (Expression<Func<TEntity, object>> selector, object value)[]? filters
    ) where TEntity : class
    {
        IQueryable<TEntity> query = dbContext.Set<TEntity>();

        if (filters is not { Length: > 0 })
            return await query
                .Select(selector)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();

        var parameter = Expression.Parameter(typeof(TEntity), "x");
        Expression? combined = null;

        foreach (var (fSelector, fValue) in filters)
        {
            var property = fSelector.Body;

            if (property is UnaryExpression { NodeType: ExpressionType.Convert } unary)
                property = unary.Operand;

            property = new ParameterReplacer(fSelector.Parameters[0], parameter).Visit(property)!;

            var constant = Expression.Constant(fValue, property.Type);
            var equal = Expression.Equal(property, constant);
            combined = combined == null ? equal : Expression.AndAlso(combined, equal);
        }

        var lambda = Expression.Lambda<Func<TEntity, bool>>(combined!, parameter);
        query = query.Where(lambda);

        return await query
            .Select(selector)
            .Distinct()
            .OrderBy(x => x)
            .ToListAsync();
    }

    private class ParameterReplacer(ParameterExpression oldParameter, ParameterExpression newParameter)
        : ExpressionVisitor
    {
        protected override Expression VisitParameter(ParameterExpression node)
            => node == oldParameter ? newParameter : node;
    }

    private static Expression<Func<TEntity, int>> BuildCommonNumberSelector<TEntity>()
    {
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var commonProperty = Expression.Property(parameter, "Common");
        var numberProperty = Expression.Property(commonProperty, "Number");
        return Expression.Lambda<Func<TEntity, int>>(numberProperty, parameter);
    }

    // Helper: build expression x => x.Common.Number == number
    private static Expression<Func<TEntity, bool>> BuildCommonNumberPredicate<TEntity>(int number)
    {
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var commonProperty = Expression.Property(parameter, "Common");
        var numberProperty = Expression.Property(commonProperty, "Number");
        var constant = Expression.Constant(number);
        var equal = Expression.Equal(numberProperty, constant);
        return Expression.Lambda<Func<TEntity, bool>>(equal, parameter);
    }
}
