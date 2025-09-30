using Database;
using Microsoft.EntityFrameworkCore;
using Models;
using Repos.Interfaces;

namespace Repos;

public class CarRepo(AppDbContext dbContext) : BaseRepo(dbContext), ICarRepo
{
    public async Task<List<CarDto>> FetchAllAsync()
    {
        return await DbContext.Cars.ToListAsync();
    }

public async Task<CarDto?> FetchByIdAsync(string id)
    {
        return await DbContext.Cars
            .FirstOrDefaultAsync(c => c.Common.Id == id);
    }

    public async Task<List<CarDto>> FetchByDateRangeAsync(DateTime start, DateTime end)
    {
        return await DbContext.Cars
            .Where(c => c.DateRange.StartDate >= start && c.DateRange.EndDate <= end)
            .ToListAsync();
    }
}
