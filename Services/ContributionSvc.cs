using Models;
using Repos.Interfaces;
using Services.Interfaces;

namespace Services;

public class ContributionSvc(IContributionRepo repo) : IContributionSvc
{
    public Task<List<ContributionDto>> GetAllContributionsAsync() => repo.FetchAllAsync();

    public Task<ContributionDto?> GetContributionByIdAsync(string id) => repo.FetchByIdAsync(id);

    public Task<List<ContributionDto>> GetContributionsByDateAsync(DateTime date) => repo.FetchByDateAsync(date);

    public Task<List<ContributionDto>> GetContributionsByYearAsync(int year) => repo.FetchByYearAsync(year);

    public Task<List<ContributionDto>> GetContributionsByAmountRangeAsync(decimal? min, decimal? max)
        => repo.FetchByAmountRangeAsync(min, max);

    public Task<List<ContributionDto>> GetContributionsByAccountAsync(string account) => repo.FetchByAccountAsync(account);

    public Task<List<ContributionDto>> GetExcludedContributionsAsync() => repo.FetchExcludedAsync();
}