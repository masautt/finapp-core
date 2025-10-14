using System.Linq.Expressions;
using Database;
using Microsoft.EntityFrameworkCore;

namespace Repos.Transums.Shared;

public class TransumCommonRepo<TEntity, TKey>(AppDbContext dbContext, Expression<Func<TEntity, TKey>> keySelector)
    where TEntity : class
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    private readonly Expression<Func<TEntity, TKey>> _keySelector = keySelector ?? throw new ArgumentNullException(nameof(keySelector));

    public async Task<List<TKey>> FetchAllUniqueKeysAsync()
    {
        return await _dbContext.Set<TEntity>()
            .Select(_keySelector)
            .Distinct()
            .ToListAsync();
    }

    public async Task<TEntity?> FetchByKeyAsync(TKey key)
    {
        var param = _keySelector.Parameters.Single();
        var body = Expression.Equal(_keySelector.Body, Expression.Constant(key));
        var predicate = Expression.Lambda<Func<TEntity, bool>>(body, param);

        return await _dbContext.Set<TEntity>()
            .SingleOrDefaultAsync(predicate);
    }

    public async Task<TEntity?> FetchRandomAsync() =>
        await _dbContext.Set<TEntity>().OrderBy(e => Guid.NewGuid()).FirstOrDefaultAsync();

    public async Task<int> FetchCountAsync() =>
        await _dbContext.Set<TEntity>().CountAsync();
}