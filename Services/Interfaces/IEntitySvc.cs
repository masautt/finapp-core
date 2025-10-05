using Models.Tables;
using System.Linq.Expressions;

namespace Services.Interfaces;

public interface IEntitySvc<TEntity> where TEntity : class
{
    // CommonSvc methods
    Task<TEntity?> FetchById(string id);
    Task<int> FetchTotalCount();
    Task<TEntity?> FetchLatestRecord(Expression<Func<TEntity, bool>>? predicate = null);
    Task<TEntity?> FetchOldestRecord(Expression<Func<TEntity, bool>>? predicate = null);
    Task<TEntity?> FetchRandomRecord();
    Task<TEntity?> FetchByNumber(int number);
    Task<List<TEntity>> FetchByCustom(params (Expression<Func<TEntity, object>> selector, object value)[] filters);

    // DateSvc methods
    Task<List<TEntity>> FetchByDateRange(
        DateTime start,
        DateTime end,
        Expression<Func<TEntity, DateRangeFields>> dateSelector);

    Task<List<TEntity>> FetchByDateRangeWithExactDateFields(
        DateTime start,
        DateTime end,
        Expression<Func<TEntity, ExactDateFields>> exactDateSelector);
}