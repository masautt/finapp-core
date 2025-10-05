using Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repos.Shared;

public class CommonRepo(AppDbContext dbContext)
{
    public async Task<TEntity?> FetchById<TEntity>(string id) where TEntity : class
        => await dbContext.Set<TEntity>().FindAsync(id);

    public async Task<int> FetchTotalCount<TEntity>() where TEntity : class
        => await dbContext.Set<TEntity>().CountAsync();

    public async Task<TEntity?> GetLastRecord<TEntity>(
        Expression<Func<TEntity, bool>>? predicate = null
    ) where TEntity : class
    {
        IQueryable<TEntity> query = dbContext.Set<TEntity>();

        if (predicate != null)
            query = query.Where(predicate);

        // Build dynamic expression for "Common.Number"
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var commonProperty = Expression.Property(parameter, "Common");
        var numberProperty = Expression.Property(commonProperty, "Number");
        var lambda = Expression.Lambda<Func<TEntity, int>>(numberProperty, parameter);

        return await query.OrderByDescending(lambda).FirstOrDefaultAsync();
    }


    public async Task<List<TEntity>> FetchByCustom<TEntity>(
        Dictionary<string, object> filters
    ) where TEntity : class
    {
        IQueryable<TEntity> query = dbContext.Set<TEntity>();

        if (filters == null || filters.Count == 0)
            return await query.ToListAsync();

        // Build predicate dynamically
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        Expression? combined = null;

        foreach (var (propName, value) in filters)
        {
            var property = Expression.Property(parameter, propName);
            var constant = Expression.Constant(value);
            var equal = Expression.Equal(property, constant);
            combined = combined == null ? equal : Expression.AndAlso(combined, equal);
        }

        var lambda = Expression.Lambda<Func<TEntity, bool>>(combined!, parameter);
        return await query.Where(lambda).ToListAsync();
    }
}