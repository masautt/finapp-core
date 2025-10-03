using Repos.Shared;
using Services.Interfaces;
using System.Threading.Tasks;

namespace Services.Shared;

public class CommonSvc : ICommonSvc
{
    private readonly CommonRepo _commonRepo;

    protected CommonSvc(CommonRepo commonRepo)
    {
        _commonRepo = commonRepo ?? throw new ArgumentNullException(nameof(commonRepo));
    }

    public Task<TEntity?> FetchById<TEntity, TKey>(TKey id) where TEntity : class
        => _commonRepo.FetchById<TEntity, TKey>(id);

    public Task<int> FetchTotalCount<TEntity>() where TEntity : class
        => _commonRepo.FetchTotalCount<TEntity>();
}