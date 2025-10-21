using Models.Tables;
using Repos.Tables;
using Services.Tables.Interfaces;
using Services.Tables.Shared;

namespace Services.Tables;

public class BudgetSvc(EntityRepo entityRepo) : EntitySvc<BudgetDto>(entityRepo), IBudgetSvc;