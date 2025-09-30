using Database;
using Microsoft.EntityFrameworkCore;
using Models;
using Repos.Interfaces;

namespace Repos;

public class HousingRepo(AppDbContext dbContext) : IHousingRepo
{
    public async Task<List<HousingDto>> FetchAllAsync()
    {
        return await dbContext.Housings.ToListAsync();
    }

    public async Task<HousingDto?> FetchByIdAsync(string id)
    {
        return await dbContext.Housings
            .FirstOrDefaultAsync(h => h.Common.Id == id);
    }

    public async Task<List<HousingDto>> FetchByDateRangeAsync(DateTime start, DateTime end)
    {
        return await dbContext.Housings
            .Where(h => h.DateRange.StartDate >= start && h.DateRange.EndDate <= end)
            .ToListAsync();
    }

    public async Task<List<HousingDto>> FetchByRentAmountAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Housings.AsQueryable();
        if (min.HasValue) query = query.Where(h => h.RentAmount >= min.Value);
        if (max.HasValue) query = query.Where(h => h.RentAmount <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<HousingDto>> FetchByTotalUtilitiesAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Housings.AsQueryable();
        if (min.HasValue) query = query.Where(h => h.TotalUtilities >= min.Value);
        if (max.HasValue) query = query.Where(h => h.TotalUtilities <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<HousingDto>> FetchByTotalHousingAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Housings.AsQueryable();
        if (min.HasValue) query = query.Where(h => h.TotalHousing >= min.Value);
        if (max.HasValue) query = query.Where(h => h.TotalHousing <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<HousingDto>> FetchByCityServiceAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Housings.AsQueryable();
        if (min.HasValue) query = query.Where(h => h.CityServices >= min.Value);
        if (max.HasValue) query = query.Where(h => h.CityServices <= max.Value);
        return await query.ToListAsync();
    }
}
