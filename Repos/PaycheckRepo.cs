using Database;
using Microsoft.EntityFrameworkCore;
using Models;
using Repos.Interfaces;

namespace Repos;

public class PaycheckRepo(AppDbContext dbContext) : IPaycheckRepo
{
    public async Task<List<PaycheckDto>> FetchAllAsync()
    {
        return await dbContext.Paychecks.ToListAsync();
    }

    public async Task<PaycheckDto?> FetchByIdAsync(string id)
    {
        return await dbContext.Paychecks
            .FirstOrDefaultAsync(p => p.Common.Id == id);
    }

    public async Task<List<PaycheckDto>> FetchByDateRangeAsync(DateTime start, DateTime end)
    {
        return await dbContext.Paychecks
            .Where(p => p.DateRange.StartDate >= start && p.DateRange.EndDate <= end)
            .ToListAsync();
    }

    public async Task<List<PaycheckDto>> FetchByHoursPaidAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Paychecks.AsQueryable();
        if (min.HasValue) query = query.Where(p => p.HoursPaid >= min.Value);
        if (max.HasValue) query = query.Where(p => p.HoursPaid <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<PaycheckDto>> FetchByPayRateAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Paychecks.AsQueryable();
        if (min.HasValue) query = query.Where(p => p.PayRate >= min.Value);
        if (max.HasValue) query = query.Where(p => p.PayRate <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<PaycheckDto>> FetchByGrossEarningsAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Paychecks.AsQueryable();
        if (min.HasValue) query = query.Where(p => p.GrossEarnings >= min.Value);
        if (max.HasValue) query = query.Where(p => p.GrossEarnings <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<PaycheckDto>> FetchByNetPayAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Paychecks.AsQueryable();
        if (min.HasValue) query = query.Where(p => p.NetPay >= min.Value);
        if (max.HasValue) query = query.Where(p => p.NetPay <= max.Value);
        return await query.ToListAsync();
    }
}
