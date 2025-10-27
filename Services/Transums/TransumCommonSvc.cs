using Models.Transums;
using Repos.Transums;
using System.Linq.Expressions;

namespace Services.Transums;

public class TransumCommonSvc<TEntity, TKey>(TransumCommonRepo<TEntity, TKey> repo)
    where TEntity : class
{
    public async Task<List<TKey>> FetchAllUniqueKeysAsync()
    {
        return await repo.FetchAllUniqueKeysAsync();
    }

    public async Task<TEntity?> FetchByKeyAsync(TKey key)
    {
        return await repo.FetchByKeyAsync(key);
    }

    public async Task<bool> KeyExistsAsync(TKey key)
    {
        return await repo.KeyExistsAsync(key);
    }

    public async Task<TEntity?> FetchRandomAsync(
        params Expression<Func<TEntity, bool>>[]? predicates)
    {
        return await repo.FetchRandomAsync(predicates);
    }

    public async Task<int> FetchCountAsync(
        params Expression<Func<TEntity, bool>>[]? predicates)
    {
        return await repo.FetchCountAsync(predicates);
    }

    public async Task<List<TEntity>> FetchBySortOrderAsync<TOrderBy>(
        Expression<Func<TransumCommonDto, TOrderBy>> orderBy,
        bool descending = false,
        int? limit = null)
    {
        return await repo.FetchBySortOrderAsync(orderBy, descending, limit);
    }

    public async Task<bool> AnyAsync(
        params Expression<Func<TEntity, bool>>[] predicates)
    {
        return await repo.AnyAsync(predicates);
    }
}