using Models;

namespace Services.Interfaces;

public interface ICarSvc
{
    Task<List<CarDto>> GetAllCarsAsync();
    Task<CarDto?> GetCarByIdAsync(string id);

    Task<List<CarDto>> GetCarsByDateRangeAsync(DateTime start, DateTime end);

    Task<List<CarDto>> GetCarsByPaymentAmountAsync(decimal? min, decimal? max);
    Task<List<CarDto>> GetCarsByPrincipalAsync(decimal? min, decimal? max);
    Task<List<CarDto>> GetCarsByInterestAsync(decimal? min, decimal? max);
    Task<List<CarDto>> GetCarsByOwedAsync(decimal? min, decimal? max);
    Task<List<CarDto>> GetCarsByInsuranceAmountAsync(decimal? min, decimal? max);
    Task<List<CarDto>> GetCarsByMilesAddedAsync(decimal? min, decimal? max);
    Task<List<CarDto>> GetCarsByTotalAsync(decimal? min, decimal? max);
}