using Database;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services;

public class HousingSvc : IHousingSvc
{
    private readonly AppDbContext _dbContext;

    public HousingSvc(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<HousingDto>> GetAllHousingsAsync()
    {
        return await _dbContext.Housings.ToListAsync();
    }

    public async Task<HousingDto?> GetHousingByIdAsync(string id)
    {
        return await _dbContext.Housings
            .FirstOrDefaultAsync(h => h.Common.Id == id);
    }

    public async Task<List<HousingDto>> GetHousingsByDateRangeAsync(DateTime start, DateTime end)
    {
        return await _dbContext.Housings
            .Where(h => h.DateRange.StartDate >= start && h.DateRange.EndDate <= end)
            .ToListAsync();
    }

    public async Task<List<HousingDto>> GetHousingsByRentAmountAsync(decimal? min, decimal? max)
    {
        var query = _dbContext.Housings.AsQueryable();

        if (min.HasValue) query = query.Where(h => h.RentAmount >= min.Value);
        if (max.HasValue) query = query.Where(h => h.RentAmount <= max.Value);

        return await query.ToListAsync();
    }

    public async Task<List<HousingDto>> GetHousingsByTotalUtilitiesAsync(decimal? min, decimal? max)
    {
        var query = _dbContext.Housings.AsQueryable();

        if (min.HasValue) query = query.Where(h => h.TotalUtilities >= min.Value);
        if (max.HasValue) query = query.Where(h => h.TotalUtilities <= max.Value);

        return await query.ToListAsync();
    }

    public async Task<List<HousingDto>> GetHousingsByTotalHousingAsync(decimal? min, decimal? max)
    {
        var query = _dbContext.Housings.AsQueryable();

        if (min.HasValue) query = query.Where(h => h.TotalHousing >= min.Value);
        if (max.HasValue) query = query.Where(h => h.TotalHousing <= max.Value);

        return await query.ToListAsync();
    }

    public async Task<List<HousingDto>> GetHousingsByCityServiceAsync(decimal? min, decimal? max)
    {
        var query = _dbContext.Housings.AsQueryable();

        if (min.HasValue) query = query.Where(h => h.CityServices >= min.Value);
        if (max.HasValue) query = query.Where(h => h.CityServices <= max.Value);

        return await query.ToListAsync();
    }
}
