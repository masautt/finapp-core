using Database;
using Microsoft.EntityFrameworkCore;
using Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repos.Shared;

public class DateRepo
{
    private readonly AppDbContext _dbContext;

    public DateRepo(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<List<T>> FetchByDateRange<T>(
        DateTime start,
        DateTime end,
        Expression<Func<T, DateRangeFields>> dateSelector
    ) where T : class
    {
        if (start > end) throw new ArgumentException("Start date must be before end date.");

        // Build the EF-friendly expression: x => x.DateRange.StartDate <= end && x.DateRange.EndDate >= start
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

    public async Task<List<T>> FetchByExactDateRange<T>(
        DateTime start,
        DateTime end,
        Expression<Func<T, DateTime>> dateSelector
    ) where T : class
    {
        if (start > end) throw new ArgumentException("Start date must be before end date.");

        // Directly build expression: x => x.PaymentDate >= start && x.PaymentDate <= end
        var param = dateSelector.Parameters[0];

        var body = Expression.AndAlso(
            Expression.GreaterThanOrEqual(dateSelector.Body, Expression.Constant(start)),
            Expression.LessThanOrEqual(dateSelector.Body, Expression.Constant(end))
        );

        var lambda = Expression.Lambda<Func<T, bool>>(body, param);

        return await _dbContext.Set<T>().Where(lambda).ToListAsync();
    }
}