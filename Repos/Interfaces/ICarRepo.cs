using Models;

namespace Repos.Interfaces;

public interface ICarRepo
{
    Task<List<CarDto>> FetchAllAsync();
    Task<CarDto?> FetchByIdAsync(string id);
    Task<List<CarDto>> FetchByDateRangeAsync(DateTime start, DateTime end);
    Task<List<CarDto>> FetchByPaymentAmountAsync(decimal? min, decimal? max);
    Task<List<CarDto>> FetchByPrincipalAsync(decimal? min, decimal? max);
    Task<List<CarDto>> FetchByInterestAsync(decimal? min, decimal? max);
    Task<List<CarDto>> FetchByOwedAsync(decimal? min, decimal? max);
    Task<List<CarDto>> FetchByInsuranceAmountAsync(decimal? min, decimal? max);
    Task<List<CarDto>> FetchByMilesAddedAsync(decimal? min, decimal? max);
    Task<List<CarDto>> FetchByTotalAsync(decimal? min, decimal? max);
}
