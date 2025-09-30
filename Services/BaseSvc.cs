using Repos;
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services;

public abstract class BaseSvc<TEntity, TRepo>(TRepo repo) : IBaseSvc<TEntity>
    where TEntity : class
    where TRepo : BaseRepo
{
    // Must be public to satisfy IBaseSvc
    public Task<TEntity?> GetById<TKey>(TKey id)
        => repo.FetchById<TEntity, TKey>(id);

    public Task<int> GetTotalCount()
        => repo.FetchTotalCount<TEntity>();

    public Task<BaseRepo.PaginatedResponse<TEntity>> GetAll(
        int? page = null,
        int? pageSize = null
    ) => repo.FetchByCustom<TEntity, TEntity>(
        page ?? 1,
        pageSize ?? 100
    );

    public Task<BaseRepo.PaginatedResponse<TEntity>> GetByNumRange(
        Expression<Func<TEntity, decimal>> selector,
        int start,
        int end,
        int? page = null,
        int? pageSize = null
    ) => repo.FetchByCustom<TEntity, TEntity>(
        page ?? 1,
        pageSize ?? 100,
        filter: e => EF.Property<decimal>(e, ((MemberExpression)selector.Body).Member.Name) >= start &&
                     EF.Property<decimal>(e, ((MemberExpression)selector.Body).Member.Name) <= end
    );

    public Task<BaseRepo.PaginatedResponse<TEntity>> GetByDateRange(
        Expression<Func<TEntity, DateTime>> selector,
        DateTime start,
        DateTime end,
        int? page = null,
        int? pageSize = null
    )
    {
        return repo.FetchByCustom<TEntity, TEntity>(
            page ?? 1,
            pageSize ?? 100,
            filter: e => selector.Compile()(e) >= start && selector.Compile()(e) <= end
        );
    }


    public Task<BaseRepo.PaginatedResponse<TEntity>> GetAll(int page = 1, int pageSize = 100)
    {
        throw new NotImplementedException();
    }

    public Task<BaseRepo.PaginatedResponse<TEntity>> GetByNumRange(Expression<Func<TEntity, decimal>> selector, decimal start, decimal end, int? page = 1, int? pageSize = 100)
    {
        throw new NotImplementedException();
    }
}