using Models;
using Repos.Interfaces;
using Services.Interfaces;

namespace Services;

public class CarSvc(ICarRepo repo) : ICarSvc
{
    public Task<List<CarDto>> GetAllCarsAsync() => repo.FetchAllAsync();

    public Task<CarDto?> GetCarByIdAsync(string id) => repo.FetchByIdAsync(id);

    public Task<List<CarDto>> GetCarsByDateRangeAsync(DateTime start, DateTime end)
        => repo.FetchByDateRangeAsync(start, end);

    public Task<List<CarDto>> GetCarsByPaymentAmountAsync(decimal? min, decimal? max)
        => repo.FetchByPaymentAmountAsync(min, max);

    public Task<List<CarDto>> GetCarsByPrincipalAsync(decimal? min, decimal? max)
        => repo.FetchByPrincipalAsync(min, max);

    public Task<List<CarDto>> GetCarsByInterestAsync(decimal? min, decimal? max)
        => repo.FetchByInterestAsync(min, max);

    public Task<List<CarDto>> GetCarsByOwedAsync(decimal? min, decimal? max)
        => repo.FetchByOwedAsync(min, max);

    public Task<List<CarDto>> GetCarsByInsuranceAmountAsync(decimal? min, decimal? max)
        => repo.FetchByInsuranceAmountAsync(min, max);

    public Task<List<CarDto>> GetCarsByMilesAddedAsync(decimal? min, decimal? max)
        => repo.FetchByMilesAddedAsync(min, max);

    public Task<List<CarDto>> GetCarsByTotalAsync(decimal? min, decimal? max)
        => repo.FetchByTotalAsync(min, max);
}