using Models.Tables;
using Repos.Tables;
using Services.Tables.Interfaces;
using Services.Tables.Shared;

namespace Services.Tables;

public class ContributionTableSvc(TableEntityRepo entityRepo) : EntityTableSvc<ContributionTableDto>(entityRepo), IContributionTableSvc;