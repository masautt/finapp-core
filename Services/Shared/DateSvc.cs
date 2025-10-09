using System.Linq.Expressions;
using Models.Tables;
using Repos.Shared;

namespace Services.Shared;

public class DateSvc<TEntity>(DateRepo dateRepo) where TEntity : class
{
    private readonly DateRepo _dateRepo = dateRepo ?? throw new ArgumentNullException(nameof(dateRepo));

    public Task<List<TEntity>> FetchByDateRange(
        DateTime start,
        DateTime end,
        Expression<Func<TEntity, DateRangeFields>> dateSelector)
        => _dateRepo.FetchByDateRange(start, end, dateSelector);

    public Task<List<TEntity>> FetchByDateRangeWithExactDateFields(
        DateTime start,
        DateTime end,
        Expression<Func<TEntity, ExactDateFields>> exactDateSelector)
        => _dateRepo.FetchByDateRangeWithExactDateFields(start, end, exactDateSelector);
}