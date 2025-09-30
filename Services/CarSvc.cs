using Database;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services;

public class CarSvc : ICarSvc
{
    private readonly AppDbContext _dbContext;
public CarSvc(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CarDto>> GetAllCarsAsync()
    {
        return await _dbContext.Cars.ToListAsync();
    }

    public async Task<CarDto?> GetCarByIdAsync(string id)
    {
        return await _dbContext.Cars
            .FirstOrDefaultAsync(c => c.Common.Id == id);
    }

    public async Task<List<CarDto>> GetCarsByDateRangeAsync(DateTime start, DateTime end)
    {
        return await _dbContext.Cars
            .Where(c => c.DateRange.StartDate >= start && c.DateRange.EndDate <= end)
            .ToListAsync();
    }

    public async Task<List<CarDto>> GetCarsByPaymentAmountAsync(decimal? min, decimal? max)
    {
        var query = _dbContext.Cars.AsQueryable();
        if (min.HasValue) query = query.Where(c => c.PaymentAmount >= min.Value);
        if (max.HasValue) query = query.Where(c => c.PaymentAmount <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<CarDto>> GetCarsByPrincipalAsync(decimal? min, decimal? max)
    {
        var query = _dbContext.Cars.AsQueryable();
        if (min.HasValue) query = query.Where(c => c.Principal >= min.Value);
        if (max.HasValue) query = query.Where(c => c.Principal <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<CarDto>> GetCarsByInterestAsync(decimal? min, decimal? max)
    {
        var query = _dbContext.Cars.AsQueryable();
        if (min.HasValue) query = query.Where(c => c.Interest >= min.Value);
        if (max.HasValue) query = query.Where(c => c.Interest <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<CarDto>> GetCarsByOwedAsync(decimal? min, decimal? max)
    {
        var query = _dbContext.Cars.AsQueryable();
        if (min.HasValue) query = query.Where(c => c.Owed >= min.Value);
        if (max.HasValue) query = query.Where(c => c.Owed <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<CarDto>> GetCarsByInsuranceAmountAsync(decimal? min, decimal? max)
    {
        var query = _dbContext.Cars.AsQueryable();
        if (min.HasValue) query = query.Where(c => c.InsuranceAmount >= min.Value);
        if (max.HasValue) query = query.Where(c => c.InsuranceAmount <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<CarDto>> GetCarsByMilesAddedAsync(decimal? min, decimal? max)
    {
        var query = _dbContext.Cars.AsQueryable();
        if (min.HasValue) query = query.Where(c => c.MilesAdded >= min.Value);
        if (max.HasValue) query = query.Where(c => c.MilesAdded <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<CarDto>> GetCarsByTotalAsync(decimal? min, decimal? max)
    {
        var query = _dbContext.Cars.AsQueryable();
        if (min.HasValue) query = query.Where(c => c.Total >= min.Value);
        if (max.HasValue) query = query.Where(c => c.Total <= max.Value);
        return await query.ToListAsync();
    }

}
