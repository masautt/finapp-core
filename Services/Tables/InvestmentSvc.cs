using Models.Tables;
using Repos.Shared;
using Services.Interfaces;
using Services.Shared;

namespace Services.Tables;

public class InvestmentSvc(EntityRepo entityRepo) : EntitySvc<InvestmentDto>(entityRepo), IInvestmentSvc;