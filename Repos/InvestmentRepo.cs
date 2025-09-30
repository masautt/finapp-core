using Database;
using Microsoft.EntityFrameworkCore;
using Models;
using Repos.Interfaces;

namespace Repos;

public class InvestmentRepo(AppDbContext dbContext) : IInvestmentRepo
{
    public async Task<List<InvestmentDto>> FetchAllAsync()
    {
        return await dbContext.Investments.ToListAsync();
    }

public async Task<InvestmentDto?> FetchByIdAsync(string id)
    {
        return await dbContext.Investments
            .FirstOrDefaultAsync(i => i.Common.Id == id);
    }

    public async Task<List<InvestmentDto>> FetchByDateRangeAsync(DateTime start, DateTime end)
    {
        return await dbContext.Investments
            .Where(i => i.Date.StartDate >= start && i.Date.EndDate <= end)
            .ToListAsync();
    }

    public async Task<List<InvestmentDto>> FetchByBeginningBalanceAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Investments.AsQueryable();
        if (min.HasValue) query = query.Where(i => i.BeginningBalance >= min.Value);
        if (max.HasValue) query = query.Where(i => i.BeginningBalance <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<InvestmentDto>> FetchByEndingBalanceAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Investments.AsQueryable();
        if (min.HasValue) query = query.Where(i => i.EndingBalance >= min.Value);
        if (max.HasValue) query = query.Where(i => i.EndingBalance <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<InvestmentDto>> FetchByChangeInValueAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Investments.AsQueryable();
        if (min.HasValue) query = query.Where(i => i.ChangeInValue >= min.Value);
        if (max.HasValue) query = query.Where(i => i.ChangeInValue <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<InvestmentDto>> FetchByChangeInPercentageAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Investments.AsQueryable();
        if (min.HasValue) query = query.Where(i => i.ChangeInPercentage >= min.Value);
        if (max.HasValue) query = query.Where(i => i.ChangeInPercentage <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<InvestmentDto>> FetchByTypeAsync(string type)
    {
        return await dbContext.Investments
            .Where(i => i.Type == type)
            .ToListAsync();
    }

}
