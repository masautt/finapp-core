using Models;

namespace Repos.Interfaces;

public interface ICarRepo
{
    Task<List<CarDto>> FetchAllAsync();
    Task<CarDto?> FetchByIdAsync(string id);
    Task<List<CarDto>> FetchByDateRangeAsync(DateTime start, DateTime end);
}
