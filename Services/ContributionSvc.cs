using Database;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace Services;

public class ContributionSvc(AppDbContext dbContext) : IContributionSvc
{
    public async Task<List<ContributionDto>> GetAllContributionsAsync()
    {
        return await dbContext.Contributions.ToListAsync();
    }

    public async Task<ContributionDto?> GetContributionByIdAsync(string id)
    {
        return await dbContext.Contributions
            .FirstOrDefaultAsync(c => c.Common.Id == id);
    }

    public async Task<List<ContributionDto>> GetContributionsByDateAsync(DateTime date)
    {
        return await dbContext.Contributions
            .Where(c => c.Date.Date.Date == date.Date)
            .ToListAsync();
    }

    public async Task<List<ContributionDto>> GetContributionsByYearAsync(int year)
    {
        return await dbContext.Contributions
            .Where(c => c.Date.Year == year)
            .ToListAsync();
    }

    public async Task<List<ContributionDto>> GetContributionsByAmountRangeAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Contributions.AsQueryable();

        if (min.HasValue) query = query.Where(c => c.Amount >= min.Value);
        if (max.HasValue) query = query.Where(c => c.Amount <= max.Value);

        return await query.ToListAsync();
    }

    public async Task<List<ContributionDto>> GetContributionsByAccountAsync(string account)
    {
        return await dbContext.Contributions
            .Where(c => c.Account == account)
            .ToListAsync();
    }

    public async Task<List<ContributionDto>> GetExcludedContributionsAsync()
    {
        return await dbContext.Contributions
            .Where(c => c.Exclude == true)
            .ToListAsync();
    }
}