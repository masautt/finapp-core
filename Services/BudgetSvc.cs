using Models;
using Repos;
using Repos.Interfaces;
using Services.Interfaces;

namespace Services;

public class BudgetSvc(IBudgetRepo budgetRepo) : IBudgetSvc
{
    public Task<List<BudgetDto>> GetAllBudgetsAsync() => budgetRepo.GetAllBudgetsAsync();

    public Task<BudgetDto?> GetBudgetByIdAsync(string id) => budgetRepo.GetBudgetByIdAsync(id);

    public Task<List<BudgetDto>> GetBudgetsByCategoryAsync(string category) => budgetRepo.GetBudgetsByCategoryAsync(category);

    public Task<List<BudgetDto>> GetBudgetsByAmountAsync(decimal? minAmount = null, decimal? maxAmount = null) =>
        budgetRepo.GetBudgetsByAmountAsync(minAmount, maxAmount);

}