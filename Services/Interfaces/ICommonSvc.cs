namespace Services.Interfaces;

public interface ICommonSvc
{
    Task<TEntity?> FetchById<TEntity, TKey>(TKey id) where TEntity : class;
    Task<int> FetchTotalCount<TEntity>() where TEntity : class;
}