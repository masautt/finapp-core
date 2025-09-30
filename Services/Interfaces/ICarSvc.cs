using Models;

namespace Services.Interfaces;

public interface ICarSvc
{
    Task<List<CarDto>> GetCarRows();
    Task<int> GetCarCount();
    Task<CarDto?> GetCarRowById(string id);
    Task<List<CarDto>> GetCarRowsByDateRange(DateTime start, DateTime end);
    Task<List<CarDto>> GetCarRowsByNum(int min, int max);
}