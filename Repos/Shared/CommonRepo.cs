using Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repos.Shared;

public class CommonRepo(AppDbContext dbContext)
{
    public async Task<TEntity?> FetchById<TEntity, TKey>(TKey id) where TEntity : class
        => await dbContext.Set<TEntity>().FindAsync(id);

    public async Task<int> FetchTotalCount<TEntity>() where TEntity : class
        => await dbContext.Set<TEntity>().CountAsync();

    public async Task<TEntity?> GetLastRecord<TEntity>(
        Expression<Func<TEntity, int>> numberSelector,
        Expression<Func<TEntity, bool>>? predicate = null
    ) where TEntity : class
    {
        IQueryable<TEntity> query = dbContext.Set<TEntity>();

        if (predicate != null)
            query = query.Where(predicate);

        return await query.OrderByDescending(numberSelector).FirstOrDefaultAsync();
    }
}