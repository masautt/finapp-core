using Database;
using Microsoft.EntityFrameworkCore;
using Repos.Interfaces;

namespace Repos;

public class SideGigRepo : ISideGigRepo
{
    private readonly AppDbContext _dbContext;

    public SideGigRepo(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Fetch all side gigs
    public async Task<List<SideGigDto>> GetAllSideGigsAsync()
    {
        return await _dbContext.SideGigs.ToListAsync();
    }

    // Fetch by Id
    public async Task<SideGigDto?> GetSideGigByIdAsync(string id)
    {
        return await _dbContext.SideGigs
            .FirstOrDefaultAsync(sg => sg.Common.Id == id);
    }

    // Fetch by Date Range
    public async Task<List<SideGigDto>> GetSideGigsByDateRangeAsync(DateTime start, DateTime end)
    {
        return await _dbContext.SideGigs
            .Where(sg => sg.DateRange.StartDate >= start && sg.DateRange.EndDate <= end)
            .ToListAsync();
    }

    // Fetch by Company
    public async Task<List<SideGigDto>> GetSideGigsByCompanyAsync(string company)
    {
        return await _dbContext.SideGigs
            .Where(sg => sg.Company == company)
            .ToListAsync();
    }

    // Fetch all unique companies
    public async Task<List<string>> GetAllCompaniesAsync()
    {
        return await _dbContext.SideGigs
            .Select(sg => sg.Company)
            .Distinct()
            .ToListAsync();
    }

    // Fetch by Amount Paid (min/max)
    public async Task<List<SideGigDto>> GetSideGigsByAmountPaidAsync(decimal? min = null, decimal? max = null)
    {
        var query = _dbContext.SideGigs.AsQueryable();

        if (min.HasValue) query = query.Where(sg => sg.AmountPaid >= min.Value);
        if (max.HasValue) query = query.Where(sg => sg.AmountPaid <= max.Value);

        return await query.ToListAsync();
    }

    // Fetch by Hours Worked (min/max)
    public async Task<List<SideGigDto>> GetSideGigsByHoursWorkedAsync(decimal? min = null, decimal? max = null)
    {
        var query = _dbContext.SideGigs.AsQueryable();

        if (min.HasValue) query = query.Where(sg => sg.HoursWorked.HasValue && sg.HoursWorked.Value >= min.Value);
        if (max.HasValue) query = query.Where(sg => sg.HoursWorked.HasValue && sg.HoursWorked.Value <= max.Value);

        return await query.ToListAsync();
    }
}
