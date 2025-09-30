using Repos.Interfaces;
using Services.Interfaces;

namespace Services;

public class SideGigSvc(ISideGigRepo repo) : ISideGigSvc
{
    public Task<List<SideGigDto>> GetAllSideGigsAsync() => repo.GetAllSideGigsAsync();

    public Task<SideGigDto?> GetSideGigByIdAsync(string id) => repo.GetSideGigByIdAsync(id);

    public Task<List<SideGigDto>> GetSideGigsByDateRangeAsync(DateTime start, DateTime end) =>
        repo.GetSideGigsByDateRangeAsync(start, end);

    public Task<List<SideGigDto>> GetSideGigsByCompanyAsync(string company) =>
        repo.GetSideGigsByCompanyAsync(company);

    public Task<List<string>> GetAllCompaniesAsync() => repo.GetAllCompaniesAsync();

    public Task<List<SideGigDto>> GetSideGigsByAmountPaidAsync(decimal? min = null, decimal? max = null) =>
        repo.GetSideGigsByAmountPaidAsync(min, max);

    public Task<List<SideGigDto>> GetSideGigsByHoursWorkedAsync(decimal? min = null, decimal? max = null) =>
        repo.GetSideGigsByHoursWorkedAsync(min, max);
}
