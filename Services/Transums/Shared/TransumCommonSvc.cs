using Repos.Transums.Shared;

namespace Services.Transums.Shared;

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
}