using Database;
using Microsoft.EntityFrameworkCore;
using Models.Transums;

namespace Repos.Transums;

public class TransumCatRepo(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    // Returns all category names (distinct)
    public async Task<List<string>> GetCategoriesAsync()
    {
        return await _dbContext.Set<TransumCatDto>()
            .Select(t => t.Category)
            .Distinct()
            .ToListAsync();
    }

    // Returns the TransumCatDto for a given category name
    public async Task<TransumCatDto?> GetByCategoryAsync(string category)
    {
        return await _dbContext.Set<TransumCatDto>()
            .SingleOrDefaultAsync(t => t.Category == category);
    }
}