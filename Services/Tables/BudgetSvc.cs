using Models.Tables;
using Repos;
using Repos.Interfaces;
using Services.Interfaces;

namespace Services.Tables;

public class BudgetSvc(IBudgetRepo budgetRepo) : IBudgetSvc
{

}