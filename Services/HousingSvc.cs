using Models;
using Repos.Interfaces;
using Services.Interfaces;

namespace Services;

public class HousingSvc(IHousingRepo repo) : IHousingSvc
{
    public Task<List<HousingDto>> GetAllHousingsAsync() => repo.FetchAllAsync();
    public Task<HousingDto?> GetHousingByIdAsync(string id) => repo.FetchByIdAsync(id);
    public Task<List<HousingDto>> GetHousingsByDateRangeAsync(DateTime start, DateTime end)
        => repo.FetchByDateRangeAsync(start, end);
    public Task<List<HousingDto>> GetHousingsByRentAmountAsync(decimal? min, decimal? max)
        => repo.FetchByRentAmountAsync(min, max);
    public Task<List<HousingDto>> GetHousingsByTotalUtilitiesAsync(decimal? min, decimal? max)
        => repo.FetchByTotalUtilitiesAsync(min, max);
    public Task<List<HousingDto>> GetHousingsByTotalHousingAsync(decimal? min, decimal? max)
        => repo.FetchByTotalHousingAsync(min, max);
    public Task<List<HousingDto>> GetHousingsByCityServiceAsync(decimal? min, decimal? max)
        => repo.FetchByCityServiceAsync(min, max);
}