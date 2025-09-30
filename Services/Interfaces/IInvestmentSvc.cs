using Models;

namespace Services.Interfaces;

public interface IInvestmentSvc
{
    Task<List<InvestmentDto>> GetAllInvestmentsAsync();
    Task<InvestmentDto?> GetInvestmentByIdAsync(string id);
    Task<List<InvestmentDto>> GetInvestmentsByDateRangeAsync(DateTime start, DateTime end);
    Task<List<InvestmentDto>> GetInvestmentsByBeginningBalanceAsync(decimal? min, decimal? max);
    Task<List<InvestmentDto>> GetInvestmentsByEndingBalanceAsync(decimal? min, decimal? max);
    Task<List<InvestmentDto>> GetInvestmentsByChangeInValueAsync(decimal? min, decimal? max);
    Task<List<InvestmentDto>> GetInvestmentsByChangeInPercentageAsync(decimal? min, decimal? max);
    Task<List<InvestmentDto>> GetInvestmentsByTypeAsync(string type);
}