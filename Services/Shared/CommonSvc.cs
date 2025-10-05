using Repos.Shared;
using Services.Interfaces;

namespace Services.Shared;

public class CommonSvc<TEntity>(CommonRepo repo) : ICommonSvc<TEntity> where TEntity : class
{
    private readonly CommonRepo _repo = repo ?? throw new ArgumentNullException(nameof(repo));

    public Task<TEntity?> FetchById(string id) => _repo.FetchById<TEntity>(id);

    public Task<int> FetchTotalCount() => _repo.FetchTotalCount<TEntity>();

    public Task<TEntity?> GetLastRecord() => _repo.GetLastRecord<TEntity>();

    public Task<List<TEntity>> FetchByCustom(Dictionary<string, object> filters)
        => _repo.FetchByCustom<TEntity>(filters);
}