using Repos.Tables;
using System.Linq.Expressions;

namespace Services.Interfaces;

public interface IBaseSvc<TEntity>
{
    Task<TEntity?> GetById<TKey>(TKey id);
    Task<int> GetTotalCount();

}