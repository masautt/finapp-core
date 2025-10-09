using System.Linq.Expressions;
using Repos.Shared;

namespace Services.Shared;

public class CommonSvc<TEntity>(CommonRepo repo) where TEntity : class
{
    private readonly CommonRepo _repo = repo ?? throw new ArgumentNullException(nameof(repo));

    public Task<TEntity?> FetchById(string id) => _repo.FetchById<TEntity>(id);

    public Task<TEntity?> FetchByNumber(int number) => _repo.FetchByNumber<TEntity>(number);

    public Task<int> FetchTotalCount() => _repo.FetchTotalCount<TEntity>();

    public Task<TEntity?> FetchRandomRecord() => _repo.FetchRandomRecord<TEntity>();

    public Task<TEntity?> FetchLatestRecord(Expression<Func<TEntity, bool>>? predicate = null)
        => _repo.FetchLatestRecord(predicate);

    public Task<TEntity?> FetchOldestRecord(Expression<Func<TEntity, bool>>? predicate = null)
        => _repo.FetchOldestRecord(predicate);
    public Task<List<TEntity>> FetchByCustom(params (Expression<Func<TEntity, object>> selector, object value)[] filters)
        => _repo.FetchByCustom(filters);

    public Task<List<TValue>> FetchDistinct<TValue>(
        Expression<Func<TEntity, TValue>> selector,
        params (Expression<Func<TEntity, object>> selector, object value)[] filters
    ) => _repo.FetchDistinct(selector, filters);
    
    public Task<List<TResult>> FetchProjected<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null
    )
        => _repo.FetchProjected(selector, predicate);
}