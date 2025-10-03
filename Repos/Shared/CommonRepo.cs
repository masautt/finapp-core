using Database;
using Microsoft.EntityFrameworkCore;

namespace Repos.Shared;

public class CommonRepo(AppDbContext dbContext)
{
    public async Task<TEntity?> FetchById<TEntity, TKey>(TKey id) where TEntity : class
        => await dbContext.Set<TEntity>().FindAsync(id);

    public async Task<int> FetchTotalCount<TEntity>() where TEntity : class
        => await dbContext.Set<TEntity>().CountAsync();

}