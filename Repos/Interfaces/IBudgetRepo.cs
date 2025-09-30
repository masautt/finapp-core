using Models;

namespace Repos.Interfaces;

public interface IBudgetRepo
{
    Task<List<BudgetDto>> GetAllBudgetsAsync();
    Task<BudgetDto?> GetBudgetByIdAsync(string id);
    Task<List<BudgetDto>> GetBudgetsByCategoryAsync(string category);
    Task<List<BudgetDto>> GetBudgetsByAmountAsync(decimal? minAmount = null, decimal? maxAmount = null);
}