using Repos.Transums;

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

    public async Task<TEntity?> FetchRandomAsync()
    {
        return await repo.FetchRandomAsync();
    }

    public async Task<int> FetchTotalCountAsync()
    {
        return await repo.FetchCountAsync();
    }
}