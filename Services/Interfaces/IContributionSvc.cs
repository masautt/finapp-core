using Models;

namespace Services.Interfaces;

public interface IContributionSvc
{
    Task<List<ContributionDto>> GetAllContributionsAsync();
    Task<ContributionDto?> GetContributionByIdAsync(string id);
    Task<List<ContributionDto>> GetContributionsByDateAsync(DateTime date);
    Task<List<ContributionDto>> GetContributionsByYearAsync(int year);
    Task<List<ContributionDto>> GetContributionsByAmountRangeAsync(decimal? min, decimal? max);
    Task<List<ContributionDto>> GetContributionsByAccountAsync(string account);
    Task<List<ContributionDto>> GetExcludedContributionsAsync();
}