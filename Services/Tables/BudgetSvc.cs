using Models.Tables;
using Repos.Shared;
using Services.Interfaces;
using Services.Shared;

namespace Services.Tables;

public class BudgetSvc(EntityRepo entityRepo) : EntitySvc<BudgetDto>(entityRepo), IBudgetSvc;