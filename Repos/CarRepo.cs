using Database;
using Microsoft.EntityFrameworkCore;
using Models;
using Repos.Interfaces;

namespace Repos;

public class CarRepo(AppDbContext dbContext) : ICarRepo
{
    public async Task<List<CarDto>> FetchAllAsync()
    {
        return await dbContext.Cars.ToListAsync();
    }

public async Task<CarDto?> FetchByIdAsync(string id)
    {
        return await dbContext.Cars
            .FirstOrDefaultAsync(c => c.Common.Id == id);
    }

    public async Task<List<CarDto>> FetchByDateRangeAsync(DateTime start, DateTime end)
    {
        return await dbContext.Cars
            .Where(c => c.DateRange.StartDate >= start && c.DateRange.EndDate <= end)
            .ToListAsync();
    }

    public async Task<List<CarDto>> FetchByPaymentAmountAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Cars.AsQueryable();
        if (min.HasValue) query = query.Where(c => c.PaymentAmount >= min.Value);
        if (max.HasValue) query = query.Where(c => c.PaymentAmount <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<CarDto>> FetchByPrincipalAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Cars.AsQueryable();
        if (min.HasValue) query = query.Where(c => c.Principal >= min.Value);
        if (max.HasValue) query = query.Where(c => c.Principal <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<CarDto>> FetchByInterestAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Cars.AsQueryable();
        if (min.HasValue) query = query.Where(c => c.Interest >= min.Value);
        if (max.HasValue) query = query.Where(c => c.Interest <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<CarDto>> FetchByOwedAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Cars.AsQueryable();
        if (min.HasValue) query = query.Where(c => c.Owed >= min.Value);
        if (max.HasValue) query = query.Where(c => c.Owed <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<CarDto>> FetchByInsuranceAmountAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Cars.AsQueryable();
        if (min.HasValue) query = query.Where(c => c.InsuranceAmount >= min.Value);
        if (max.HasValue) query = query.Where(c => c.InsuranceAmount <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<CarDto>> FetchByMilesAddedAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Cars.AsQueryable();
        if (min.HasValue) query = query.Where(c => c.MilesAdded >= min.Value);
        if (max.HasValue) query = query.Where(c => c.MilesAdded <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<CarDto>> FetchByTotalAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Cars.AsQueryable();
        if (min.HasValue) query = query.Where(c => c.Total >= min.Value);
        if (max.HasValue) query = query.Where(c => c.Total <= max.Value);
        return await query.ToListAsync();
    }


}
