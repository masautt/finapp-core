using Models;

namespace Repos.Interfaces;

public interface IInvestmentRepo
{
    Task<List<InvestmentDto>> FetchAllAsync();
    Task<InvestmentDto?> FetchByIdAsync(string id);
    Task<List<InvestmentDto>> FetchByDateRangeAsync(DateTime start, DateTime end);
    Task<List<InvestmentDto>> FetchByBeginningBalanceAsync(decimal? min, decimal? max);
    Task<List<InvestmentDto>> FetchByEndingBalanceAsync(decimal? min, decimal? max);
    Task<List<InvestmentDto>> FetchByChangeInValueAsync(decimal? min, decimal? max);
    Task<List<InvestmentDto>> FetchByChangeInPercentageAsync(decimal? min, decimal? max);
    Task<List<InvestmentDto>> FetchByTypeAsync(string type);
}