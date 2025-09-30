using Models;

namespace Services.Interfaces;

public interface IBudgetSvc
{
    Task<List<BudgetDto>> GetAllBudgetsAsync();
    Task<BudgetDto?> GetBudgetByIdAsync(string id);
    Task<List<BudgetDto>> GetBudgetsByCategoryAsync(string category);
    Task<List<BudgetDto>> GetBudgetsByAmountAsync(decimal? minAmount = null, decimal? maxAmount = null);
}