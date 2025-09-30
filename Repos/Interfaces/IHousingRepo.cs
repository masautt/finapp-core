using Models;

namespace Repos.Interfaces;

public interface IHousingRepo
{
    Task<List<HousingDto>> FetchAllAsync();
    Task<HousingDto?> FetchByIdAsync(string id);
    Task<List<HousingDto>> FetchByDateRangeAsync(DateTime start, DateTime end);
    Task<List<HousingDto>> FetchByRentAmountAsync(decimal? min, decimal? max);
    Task<List<HousingDto>> FetchByTotalUtilitiesAsync(decimal? min, decimal? max);
    Task<List<HousingDto>> FetchByTotalHousingAsync(decimal? min, decimal? max);
    Task<List<HousingDto>> FetchByCityServiceAsync(decimal? min, decimal? max);
}