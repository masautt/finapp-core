using Models.Tables;
using System.Linq.Expressions;

namespace Services.Tables.Shared.Interfaces;

public interface IEntitySvc<TEntity> where TEntity : class
{
    // CommonSvc methods
    Task<TEntity?> FetchById(string id);
    Task<int> FetchTotalCount();
    Task<TEntity?> FetchLatestRecord(Expression<Func<TEntity, bool>>? predicate = null);
    Task<TEntity?> FetchOldestRecord(Expression<Func<TEntity, bool>>? predicate = null);
    Task<TEntity?> FetchRandomRecord(Expression<Func<TEntity, bool>>? predicate = null);
    Task<TEntity?> FetchByNumber(int number);
    Task<List<TEntity>> FetchByCustom(params (Expression<Func<TEntity, object>> selector, object value)[] filters);

    Task<List<TResult>> FetchProjected<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>>? predicate = null
    );

    // DateSvc methods
    Task<List<TEntity>> FetchByDateRange(
        DateTime start,
        DateTime end,
        Expression<Func<TEntity, DateRangeFields>> dateSelector);

    Task<List<TEntity>> FetchByDateRangeWithExactDateFields(
        DateTime start,
        DateTime end,
        Expression<Func<TEntity, ExactDateFields>> exactDateSelector);

    Task<List<TEntity>> FetchAll(); // <-- NEW
}