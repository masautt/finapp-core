using Models;
using Repos.Interfaces;
using Services.Interfaces;

namespace Services;

public class InvestmentSvc : IInvestmentSvc
{
    private readonly IInvestmentRepo _investmentRepo;

    public InvestmentSvc(IInvestmentRepo investmentRepo)
    {
        _investmentRepo = investmentRepo;
    }

    public async Task<List<InvestmentDto>> GetAllInvestmentsAsync()
    {
        return await _investmentRepo.FetchAllAsync();
    }

    public async Task<InvestmentDto?> GetInvestmentByIdAsync(string id)
    {
        return await _investmentRepo.FetchByIdAsync(id);
    }

    public async Task<List<InvestmentDto>> GetInvestmentsByDateRangeAsync(DateTime start, DateTime end)
    {
        return await _investmentRepo.FetchByDateRangeAsync(start, end);
    }

    public async Task<List<InvestmentDto>> GetInvestmentsByBeginningBalanceAsync(decimal? min, decimal? max)
    {
        return await _investmentRepo.FetchByBeginningBalanceAsync(min, max);
    }

    public async Task<List<InvestmentDto>> GetInvestmentsByEndingBalanceAsync(decimal? min, decimal? max)
    {
        return await _investmentRepo.FetchByEndingBalanceAsync(min, max);
    }

    public async Task<List<InvestmentDto>> GetInvestmentsByChangeInValueAsync(decimal? min, decimal? max)
    {
        return await _investmentRepo.FetchByChangeInValueAsync(min, max);
    }

    public async Task<List<InvestmentDto>> GetInvestmentsByChangeInPercentageAsync(decimal? min, decimal? max)
    {
        return await _investmentRepo.FetchByChangeInPercentageAsync(min, max);
    }

    public async Task<List<InvestmentDto>> GetInvestmentsByTypeAsync(string type)
    {
        return await _investmentRepo.FetchByTypeAsync(type);
    }
}