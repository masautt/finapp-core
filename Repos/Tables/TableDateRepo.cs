using Database;
using Microsoft.EntityFrameworkCore;
using Models.Tables;
using System.Linq.Expressions;
using Models.Tables.Shared;

namespace Repos.Tables;

public class TableDateRepo(AppDbContext dbContext)
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

    public async Task<List<TEntity>> FetchByExactDateRangeAsync<TEntity>(
        DateTime startDate,
        DateTime endDate,
        Expression<Func<TEntity, ExactDateFields>> dateSelector)
        where TEntity : class
    {
        var query = _dbContext.Set<TEntity>().AsQueryable();

        var param = dateSelector.Parameters[0];
        var body = Expression.AndAlso(
            Expression.GreaterThanOrEqual(
                Expression.Property(dateSelector.Body, nameof(ExactDateFields.Date)),
                Expression.Constant(startDate)),
            Expression.LessThanOrEqual(
                Expression.Property(dateSelector.Body, nameof(ExactDateFields.Date)),
                Expression.Constant(endDate))
        );

        var lambda = Expression.Lambda<Func<TEntity, bool>>(body, param);
        return await query.Where(lambda).ToListAsync();
    }

}