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

    public Task<List<T>> FetchByExactDateRange<T>(
        DateTime start,
        DateTime end,
        Expression<Func<T, DateTime>> dateSelector
    ) where T : class
        => _dateRepo.FetchByExactDateRange(start, end, dateSelector);
}