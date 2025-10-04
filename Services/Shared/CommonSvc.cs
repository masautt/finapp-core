using Repos.Shared;
using Services.Interfaces;
using System.Linq.Expressions;

namespace Services.Shared;

public class CommonSvc(CommonRepo commonRepo) : ICommonSvc
{
    private readonly CommonRepo _commonRepo = commonRepo ?? throw new ArgumentNullException(nameof(commonRepo));

    public Task<TEntity?> FetchById<TEntity, TKey>(TKey id) where TEntity : class
        => _commonRepo.FetchById<TEntity, TKey>(id);

    public Task<int> FetchTotalCount<TEntity>() where TEntity : class
        => _commonRepo.FetchTotalCount<TEntity>();

    public Task<TEntity?> GetLastRecord<TEntity>(
        Expression<Func<TEntity, bool>>? predicate = null
    ) where TEntity : class
    {
        return _commonRepo.GetLastRecord(predicate);
    }

    public Task<List<TEntity>> FetchByCustom<TEntity>(Dictionary<string, object> filters) where TEntity : class
        => _commonRepo.FetchByCustom<TEntity>(filters);
}
