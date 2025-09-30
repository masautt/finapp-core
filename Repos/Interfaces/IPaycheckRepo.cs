using Models;

namespace Repos.Interfaces;

public interface IPaycheckRepo
{
    Task<List<PaycheckDto>> FetchAllAsync();
    Task<PaycheckDto?> FetchByIdAsync(string id);
    Task<List<PaycheckDto>> FetchByDateRangeAsync(DateTime start, DateTime end);
    Task<List<PaycheckDto>> FetchByHoursPaidAsync(decimal? min, decimal? max);
    Task<List<PaycheckDto>> FetchByPayRateAsync(decimal? min, decimal? max);
    Task<List<PaycheckDto>> FetchByGrossEarningsAsync(decimal? min, decimal? max);
    Task<List<PaycheckDto>> FetchByNetPayAsync(decimal? min, decimal? max);
}