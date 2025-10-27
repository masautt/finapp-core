using Models.Tables.Shared;
using Repos.Tables;
using System.Linq.Expressions;

namespace Services.Tables.Shared;

public class DateTableSvc<TEntity>(TableDateRepo dateRepo) where TEntity : class
{
    private readonly TableDateRepo _dateRepo = dateRepo ?? throw new ArgumentNullException(nameof(dateRepo));

    public Task<List<TEntity>> FetchByDateRange(
        DateTime start,
        DateTime end,
        Expression<Func<TEntity, DateRangeFields>> dateSelector)
        => _dateRepo.FetchByDateRange(start, end, dateSelector);

    public Task<List<TEntity>> FetchByDateRangeWithExactDateFields(
        DateTime start,
        DateTime end,
        Expression<Func<TEntity, ExactDateFields>> exactDateSelector)
        => _dateRepo.FetchByExactDateRangeAsync(start, end, exactDateSelector);
}