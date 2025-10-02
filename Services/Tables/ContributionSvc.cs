using Models.Tables;
using Repos.Interfaces;
using Services.Interfaces;

namespace Services.Tables;

public class ContributionSvc(IContributionRepo repo) : IContributionSvc
{
}