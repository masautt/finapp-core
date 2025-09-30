namespace Repos.Interfaces;

public interface ISideGigRepo
{
    Task<List<SideGigDto>> GetAllSideGigsAsync();
    Task<SideGigDto?> GetSideGigByIdAsync(string id);
    Task<List<SideGigDto>> GetSideGigsByDateRangeAsync(DateTime start, DateTime end);
    Task<List<SideGigDto>> GetSideGigsByCompanyAsync(string company);
    Task<List<string>> GetAllCompaniesAsync();
    Task<List<SideGigDto>> GetSideGigsByAmountPaidAsync(decimal? min = null, decimal? max = null);
    Task<List<SideGigDto>> GetSideGigsByHoursWorkedAsync(decimal? min = null, decimal? max = null);
}