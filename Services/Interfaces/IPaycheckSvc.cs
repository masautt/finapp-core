using Models;

namespace Services.Interfaces;

public interface IPaycheckSvc
{
    Task<List<PaycheckDto>> GetAllPaychecksAsync();
    Task<PaycheckDto?> GetPaycheckByIdAsync(string id);
    Task<List<PaycheckDto>> GetPaychecksByDateRangeAsync(DateTime start, DateTime end);
    Task<List<PaycheckDto>> GetPaychecksByHoursPaidAsync(decimal? min, decimal? max);
    Task<List<PaycheckDto>> GetPaychecksByPayRateAsync(decimal? min, decimal? max);
    Task<List<PaycheckDto>> GetPaychecksByGrossEarningsAsync(decimal? min, decimal? max);
    Task<List<PaycheckDto>> GetPaychecksByNetPayAsync(decimal? min, decimal? max);
}