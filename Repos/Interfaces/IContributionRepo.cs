using Models;

namespace Repos.Interfaces;

public interface IContributionRepo
{
    Task<List<ContributionDto>> FetchAllAsync();
    Task<ContributionDto?> FetchByIdAsync(string id);
    Task<List<ContributionDto>> FetchByDateAsync(DateTime date);
    Task<List<ContributionDto>> FetchByYearAsync(int year);
    Task<List<ContributionDto>> FetchByAmountRangeAsync(decimal? min, decimal? max);
    Task<List<ContributionDto>> FetchByAccountAsync(string account);
    Task<List<ContributionDto>> FetchExcludedAsync();
}