// BudgetRepo.cs

using Database;
using Microsoft.EntityFrameworkCore;
using Models;
using Repos.Interfaces;

namespace Repos;

public class BudgetRepo(AppDbContext dbContext) : IBudgetRepo
{
    public async Task<List<BudgetDto>> GetAllBudgetsAsync() => await dbContext.Budgets.ToListAsync();

    public async Task<BudgetDto?> GetBudgetByIdAsync(string id) => await dbContext.Budgets.FindAsync(id);

    public async Task<List<BudgetDto>> GetBudgetsByCategoryAsync(string category) =>
        await dbContext.Budgets.Where(b => b.Category == category).ToListAsync();

    public async Task<List<BudgetDto>> GetBudgetsByAmountAsync(decimal? minAmount = null, decimal? maxAmount = null)
    {
        var query = dbContext.Budgets.AsQueryable();
        if (minAmount.HasValue) query = query.Where(b => b.Amount >= minAmount.Value);
        if (maxAmount.HasValue) query = query.Where(b => b.Amount <= maxAmount.Value);
        return await query.ToListAsync();
    }
}