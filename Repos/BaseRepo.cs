using Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repos;

public abstract class BaseRepo(AppDbContext dbContext)
{
    protected readonly AppDbContext DbContext = dbContext;

    public async Task<TEntity?> FetchByIdAsync<TEntity, TKey>(TKey id) where TEntity : class
    {
        return await DbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<int> GetCountAsync<TEntity>() where TEntity : class
        => await DbContext.Set<TEntity>().CountAsync();

    public async Task<List<TEntity>> GetNumRangeAsync<TEntity>(
        Expression<Func<TEntity, decimal>> selector,
        decimal start,
        decimal end
    ) where TEntity : class
    {
        return await DbContext.Set<TEntity>()
            .Where(e => EF.Property<decimal>(e, ((MemberExpression)selector.Body).Member.Name) >= start &&
                        EF.Property<decimal>(e, ((MemberExpression)selector.Body).Member.Name) <= end)
            .ToListAsync();
    }

    public async Task<List<TEntity>> FetchByDateRangeAsync<TEntity>(
        Expression<Func<TEntity, DateTime>> selector,
        DateTime start,
        DateTime end
    ) where TEntity : class
    {
        return await DbContext.Set<TEntity>()
            .Where(e => EF.Property<DateTime>(e, ((MemberExpression)selector.Body).Member.Name) >= start &&
                        EF.Property<DateTime>(e, ((MemberExpression)selector.Body).Member.Name) <= end)
            .ToListAsync();
    }
}