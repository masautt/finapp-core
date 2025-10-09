using Models.Tables;
using Repos.Shared;
using Services.Interfaces;
using Services.Shared;

namespace Services.Tables;

public class ContributionSvc(EntityRepo entityRepo) : EntitySvc<ContributionDto>(entityRepo), IContributionSvc;