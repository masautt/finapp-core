namespace Services.Interfaces;

public interface ICommonSvc<TEntity> where TEntity : class
{
    Task<TEntity?> FetchById(string id);
    Task<int> FetchTotalCount();
    Task<TEntity?> GetLastRecord();
    Task<List<TEntity>> FetchByCustom(Dictionary<string, object> filters);
}