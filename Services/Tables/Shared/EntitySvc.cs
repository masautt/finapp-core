using System.Linq.Expressions;
using Models.Tables;
using Repos.Tables;
using Services.Tables.Shared.Interfaces;

namespace Services.Tables.Shared;

public abstract class EntitySvc<TEntity>(EntityRepo entityRepo) : IEntitySvc<TEntity>
    where TEntity : class
{
    private readonly CommonSvc<TEntity> _commonSvc = new(entityRepo.CommonRepo);
    private readonly DateSvc<TEntity> _dateSvc = new(entityRepo.DateRepo);

    // Expose CommonSvc methods
    public virtual Task<TEntity?> FetchById(string id) => _commonSvc.FetchById(id);

    public virtual Task<int> FetchTotalCount() => _commonSvc.FetchTotalCount();

    public virtual Task<TEntity?> FetchRandomRecord(Expression<Func<TEntity, bool>>? predicate = null) => _commonSvc.FetchRandomRecord(predicate);

    public virtual Task<TEntity?> FetchByNumber(int number) => _commonSvc.FetchByNumber(number);

    public virtual Task<TEntity?> FetchLatestRecord(Expression<Func<TEntity, bool>>? predicate = null)
        => _commonSvc.FetchLatestRecord(predicate);

    public virtual Task<TEntity?> FetchOldestRecord(Expression<Func<TEntity, bool>>? predicate = null)
        => _commonSvc.FetchOldestRecord(predicate);

    public virtual Task<List<TEntity>> FetchByCustom(params (Expression<Func<TEntity, object>> selector, object value)[] filters)
        => _commonSvc.FetchByCustom(filters);

    // Expose DateSvc methods
    public virtual Task<List<TEntity>> FetchByDateRange(
        DateTime start,
        DateTime end,
        Expression<Func<TEntity, DateRangeFields>> dateSelector)
        => _dateSvc.FetchByDateRange(start, end, dateSelector);

    public virtual Task<List<TEntity>> FetchByDateRangeWithExactDateFields(
        DateTime start,
        DateTime end,
        Expression<Func<TEntity, ExactDateFields>> exactDateSelector)
        => _dateSvc.FetchByDateRangeWithExactDateFields(start, end, exactDateSelector);

    public virtual Task<List<TResult>> FetchProjected<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null
    ) => _commonSvc.FetchProjected(selector, predicate);

    public virtual Task<List<TEntity>> FetchAll() => _commonSvc.FetchAll();
}