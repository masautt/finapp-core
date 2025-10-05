using Models.Tables;
using System.Linq.Expressions;

namespace Services.Interfaces;

public interface IEntitySvc<TEntity> where TEntity : class
{
    // CommonSvc methods
    Task<TEntity?> FetchById(string id);
    Task<int> FetchTotalCount();
    Task<TEntity?> GetLastRecord();
    Task<List<TEntity>> FetchByCustom(Dictionary<string, object> filters);

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