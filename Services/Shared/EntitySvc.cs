using System.Linq.Expressions;
using Models.Tables;
using Repos.Shared;
using Services.Interfaces;

namespace Services.Shared;

public abstract class EntitySvc<TEntity>(EntityRepo entityRepo) : IEntitySvc<TEntity>
    where TEntity : class
{
    private readonly CommonSvc<TEntity> _commonSvc = new(entityRepo.CommonRepo);
    private readonly DateSvc<TEntity> _dateSvc = new(entityRepo.DateRepo);


    // Expose CommonSvc methods
    public virtual Task<TEntity?> FetchById(string id)
        => _commonSvc.FetchById(id);

    public virtual Task<int> FetchTotalCount()
        => _commonSvc.FetchTotalCount();

    public virtual Task<TEntity?> GetLastRecord()
        => _commonSvc.GetLastRecord();

    public virtual Task<List<TEntity>> FetchByCustom(Dictionary<string, object> filters)
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
}