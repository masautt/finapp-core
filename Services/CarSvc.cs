using Models;
using Repos;
using Repos.Interfaces;
using Services.Interfaces;

namespace Services;

public class CarSvc(ICarRepo carRepo) : BaseSvc<CarDto, CarRepo>((CarRepo)carRepo), ICarSvc
{
    public Task<List<CarDto>> GetCarRows() => carRepo.FetchAllAsync();

    public Task<int> GetCarCount() => GetTotalCount();

    public Task<CarDto?> GetCarRowById(string id)
        => GetById(id);

    public Task<List<CarDto>> GetCarRowsByDateRange(DateTime start, DateTime end)
        => GetByDateRangeAsync(c => c.DateRange.StartDate, start, end);

    public Task<List<CarDto>> GetCarRowsByNum(int min, int max)
        => GetNumRangeAsync(c => c.Common.Number, min, max);
}