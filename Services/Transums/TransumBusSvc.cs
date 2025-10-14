using Models.Transums;
using Repos.Transums;

namespace Services.Transums;

public class TransumBusSvc(TransumBusRepo repo)
{
    public async Task<List<string>> GetUniqueBusinessesAsync()
    {
        return await repo.GetUniqueBusinessesAsync();
    }

    public async Task<TransumBusDto?> GetByBusinessAsync(string business)
    {
        return await repo.GetByBusinessAsync(business);
    }
}