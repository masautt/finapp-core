using Database;
using Microsoft.EntityFrameworkCore;
using Models.Transums;

namespace Repos.Transums;

public class TransumBusRepo(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    // Returns unique business names
    public async Task<List<string>> GetUniqueBusinessesAsync()
    {
        return await _dbContext.Set<TransumBusDto>()
            .Select(t => t.Business)
            .Distinct()
            .ToListAsync();
    }

    // Returns all TransumBusDto entries for a specific business
    public async Task<List<TransumBusDto>> GetByBusinessAsync(string business)
    {
        return await _dbContext.Set<TransumBusDto>()
            .Where(t => t.Business == business)
            .ToListAsync();
    }
}