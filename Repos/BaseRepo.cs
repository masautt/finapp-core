using Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repos;

public abstract class BaseRepo(AppDbContext dbContext)
{
    protected readonly AppDbContext DbContext = dbContext;

    public record PaginatedResponse<T>(
        List<T> Items,
        PageInfo Page
    );

    public record PageInfo(
        int PageNumber,
        int PageSize,
        int TotalItems,
        int TotalPages
    );


    public async Task<TEntity?> FetchById<TEntity, TKey>(TKey id) where TEntity : class
        => await DbContext.Set<TEntity>().FindAsync(id);

    public async Task<int> FetchTotalCount<TEntity>() where TEntity : class
        => await DbContext.Set<TEntity>().CountAsync();

    // Pagination result with metadata
    public record PaginatedResult<TResult>(
        List<TResult> Items,
        int TotalCount,
        int Page,
        int PageSize
    );


    public async Task<PaginatedResponse<TResult>> FetchByCustom<TEntity, TResult>(
        int page = 1,
        int pageSize = 100,
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity, object>>? orderBy = null,
        bool ascending = true,
        Expression<Func<TEntity, TResult>>? selector = null
    ) where TEntity : class
    {
        IQueryable<TEntity> query = DbContext.Set<TEntity>();

        if (filter != null)
            query = query.Where(filter);

        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        if (orderBy != null)
            query = ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);
        else
            query = query.OrderBy(e => EF.Property<object>(e, "Number")); // default ordering

        List<TResult> items;
        if (selector != null)
            items = await query.Skip((page - 1) * pageSize).Take(pageSize).Select(selector).ToListAsync();
        else
            items = await query.Skip((page - 1) * pageSize).Take(pageSize).Cast<TResult>().ToListAsync();

        return new PaginatedResponse<TResult>(
            Items: items,
            Page: new PageInfo(
                PageNumber: page,
                PageSize: pageSize,
                TotalItems: totalCount,
                TotalPages: totalPages
            )
        );
    }
}
