using Database;
using Microsoft.EntityFrameworkCore;
using Models.Tables;
using System.Linq.Expressions;

namespace Repos.Tables;

public class DateRepo(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<List<T>> FetchByDateRange<T>(
        DateTime start,
        DateTime end,
        Expression<Func<T, DateRangeFields>> dateSelector
    ) where T : class
    {
        if (start > end) throw new ArgumentException("Start date must be before end date.");

        var param = dateSelector.Parameters[0];

        var startProp = Expression.Property(dateSelector.Body, nameof(DateRangeFields.StartDate));
        var endProp = Expression.Property(dateSelector.Body, nameof(DateRangeFields.EndDate));

        var body = Expression.AndAlso(
            Expression.LessThanOrEqual(startProp, Expression.Constant(end)),
            Expression.GreaterThanOrEqual(endProp, Expression.Constant(start))
        );

        var lambda = Expression.Lambda<Func<T, bool>>(body, param);

        return await _dbContext.Set<T>().Where(lambda).ToListAsync();
    }

    public async Task<List<T>> FetchByDateRangeWithExactDateFields<T>(
        DateTime start,
        DateTime end,
        Expression<Func<T, ExactDateFields>> exactDateSelector
    ) where T : class
    {
        var entityParam = Expression.Parameter(typeof(T), "entity");

        // entity.Date (ExactDateFields)
        var dateFieldAccess = Expression.Invoke(exactDateSelector, entityParam);

        // entity.Date.Date (the DateTime inside ExactDateFields)
        var dateProperty = Expression.Property(dateFieldAccess, nameof(ExactDateFields.Date));

        // start <= entity.Date.Date
        var greaterThanOrEqual = Expression.GreaterThanOrEqual(dateProperty, Expression.Constant(start, typeof(DateTime)));

        // entity.Date.Date <= end
        var lessThanOrEqual = Expression.LessThanOrEqual(dateProperty, Expression.Constant(end, typeof(DateTime)));

        // Combine into (start <= entity.Date.Date && entity.Date.Date <= end)
        var body = Expression.AndAlso(greaterThanOrEqual, lessThanOrEqual);

        var lambda = Expression.Lambda<Func<T, bool>>(body, entityParam);

        return await _dbContext.Set<T>()
            .Where(lambda)
            .ToListAsync();
    }
}