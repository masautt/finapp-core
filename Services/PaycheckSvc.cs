using Models;
using Repos.Interfaces;
using Services.Interfaces;

namespace Services;

public class PaycheckSvc(IPaycheckRepo paycheckRepo) : IPaycheckSvc
{
    public async Task<List<PaycheckDto>> GetAllPaychecksAsync()
    {
        return await paycheckRepo.FetchAllAsync();
    }

    public async Task<PaycheckDto?> GetPaycheckByIdAsync(string id)
    {
        return await paycheckRepo.FetchByIdAsync(id);
    }

    public async Task<List<PaycheckDto>> GetPaychecksByDateRangeAsync(DateTime start, DateTime end)
    {
        return await paycheckRepo.FetchByDateRangeAsync(start, end);
    }

    public async Task<List<PaycheckDto>> GetPaychecksByHoursPaidAsync(decimal? min, decimal? max)
    {
        return await paycheckRepo.FetchByHoursPaidAsync(min, max);
    }

    public async Task<List<PaycheckDto>> GetPaychecksByPayRateAsync(decimal? min, decimal? max)
    {
        return await paycheckRepo.FetchByPayRateAsync(min, max);
    }

    public async Task<List<PaycheckDto>> GetPaychecksByGrossEarningsAsync(decimal? min, decimal? max)
    {
        return await paycheckRepo.FetchByGrossEarningsAsync(min, max);
    }

    public async Task<List<PaycheckDto>> GetPaychecksByNetPayAsync(decimal? min, decimal? max)
    {
        return await paycheckRepo.FetchByNetPayAsync(min, max);
    }
}