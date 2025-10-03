using System.Linq.Expressions;
using Models.Tables;
using Repos.Shared;

namespace Services.Shared;

public class DateSvc
{
    private readonly DateRepo _dateRepo;

    public DateSvc(DateRepo dateRepo)
    {
        _dateRepo = dateRepo ?? throw new ArgumentNullException(nameof(dateRepo));
    }

    public Task<List<T>> FetchByDateRange<T>(
        DateTime start,
        DateTime end,
        Expression<Func<T, DateRangeFields>> dateSelector
    ) where T : class
        => _dateRepo.FetchByDateRange(start, end, dateSelector);

    public Task<List<T>> FetchByDateRangeWithExactDateFields<T>(
        DateTime start,
        DateTime end,
        Expression<Func<T, ExactDateFields>> exactDateSelector
    ) where T : class
        => _dateRepo.FetchByDateRangeWithExactDateFields(start, end, exactDateSelector);
}