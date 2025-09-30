using Models;

namespace Services.Interfaces;

public interface IHousingSvc
{
    Task<List<HousingDto>> GetAllHousingsAsync();
    Task<HousingDto?> GetHousingByIdAsync(string id);
    Task<List<HousingDto>> GetHousingsByDateRangeAsync(DateTime start, DateTime end);
    Task<List<HousingDto>> GetHousingsByRentAmountAsync(decimal? min, decimal? max);
    Task<List<HousingDto>> GetHousingsByTotalUtilitiesAsync(decimal? min, decimal? max);
    Task<List<HousingDto>> GetHousingsByTotalHousingAsync(decimal? min, decimal? max);
    Task<List<HousingDto>> GetHousingsByCityServiceAsync(decimal? min, decimal? max);
}