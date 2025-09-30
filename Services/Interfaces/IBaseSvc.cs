using Repos;
using System.Linq.Expressions;

namespace Services.Interfaces;

public interface IBaseSvc<TEntity>
{
    Task<TEntity?> GetById<TKey>(TKey id);
    Task<int> GetTotalCount();
    Task<BaseRepo.PaginatedResponse<TEntity>> GetAll(int page = 1, int pageSize = 100);

    // Typed range queries
    Task<BaseRepo.PaginatedResponse<TEntity>> GetByNumRange(
        Expression<Func<TEntity, decimal>> selector,
        decimal start,
        decimal end,
        int? page = 1,
        int? pageSize = 100
    );

    Task<BaseRepo.PaginatedResponse<TEntity>> GetByDateRange(
        Expression<Func<TEntity, DateTime>> selector,
        DateTime start,
        DateTime end,
        int? page = 1,
        int? pageSize = 100
    );
}