using Models.Transums;
using Repos.Transums;

namespace Services.Transums;

public class TransumCatSvc(TransumCatRepo repo)
{
    public async Task<List<string>> GetCategoriesAsync()
    {
        return await repo.GetCategoriesAsync();
    }

    public async Task<TransumCatDto?> GetByCategoryAsync(string category)
    {
        return await repo.GetByCategoryAsync(category);
    }
}