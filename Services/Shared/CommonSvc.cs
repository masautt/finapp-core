using Repos.Shared;
using Services.Interfaces;

namespace Services.Shared;

public class CommonSvc(CommonRepo commonRepo) : ICommonSvc
{
    public Task<TEntity?> FetchById<TEntity, TKey>(TKey id) where TEntity : class
        => commonRepo.FetchById<TEntity, TKey>(id);

    public Task<int> FetchTotalCount<TEntity>() where TEntity : class
        => commonRepo.FetchTotalCount<TEntity>();
}