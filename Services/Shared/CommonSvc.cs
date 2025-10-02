using Repos.Shared;

namespace Services.Shared;

public class CommonSvc(CommonRepo repo)
{
    public Task<TEntity?> FetchById<TEntity, TKey>(TKey id) where TEntity : class
        => repo.FetchById<TEntity, TKey>(id);

    public Task<int> FetchTotalCount<TEntity>() where TEntity : class
        => repo.FetchTotalCount<TEntity>();
}