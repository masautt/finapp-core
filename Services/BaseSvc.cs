using Repos;
using System.Linq.Expressions;

namespace Services;

public abstract class BaseSvc<TEntity, TRepo>(TRepo repo)
    where TEntity : class
    where TRepo : BaseRepo
{
    public Task<int> GetTotalCount()
        => repo.GetCountAsync<TEntity>();

    protected Task<List<TEntity>> GetNumRangeAsync(Expression<Func<TEntity, decimal>> selector, int start, int end)
        => repo.GetNumRangeAsync(selector, start, end);

    protected Task<List<TEntity>> GetByDateRangeAsync(
        Expression<Func<TEntity, DateTime>> selector, DateTime start, DateTime end)
        => repo.FetchByDateRangeAsync(selector, start, end);

    protected Task<TEntity?> GetById<TKey>(TKey id)
        => repo.FetchByIdAsync<TEntity, TKey>(id);
}