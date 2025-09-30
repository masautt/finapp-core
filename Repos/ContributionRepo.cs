using Database;
using Microsoft.EntityFrameworkCore;
using Models;
using Repos.Interfaces;

namespace Repos;

public class ContributionRepo(AppDbContext dbContext) : IContributionRepo
{
    public async Task<List<ContributionDto>> FetchAllAsync()
    {
        return await dbContext.Contributions.ToListAsync();
    }

    public async Task<ContributionDto?> FetchByIdAsync(string id)
    {
        return await dbContext.Contributions
            .FirstOrDefaultAsync(c => c.Common.Id == id);
    }

    public async Task<List<ContributionDto>> FetchByDateAsync(DateTime date)
    {
        return await dbContext.Contributions
            .Where(c => c.Date.Date.Date == date.Date)
            .ToListAsync();
    }

    public async Task<List<ContributionDto>> FetchByYearAsync(int year)
    {
        return await dbContext.Contributions
            .Where(c => c.Date.Year == year)
            .ToListAsync();
    }

    public async Task<List<ContributionDto>> FetchByAmountRangeAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Contributions.AsQueryable();
        if (min.HasValue) query = query.Where(c => c.Amount >= min.Value);
        if (max.HasValue) query = query.Where(c => c.Amount <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<ContributionDto>> FetchByAccountAsync(string account)
    {
        return await dbContext.Contributions
            .Where(c => c.Account == account)
            .ToListAsync();
    }

    public async Task<List<ContributionDto>> FetchExcludedAsync()
    {
        return await dbContext.Contributions
            .Where(c => c.Exclude == true)
            .ToListAsync();
    }
}