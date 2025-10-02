using Models;
using Models.Tables;
using Models.Views;
using Repos.Interfaces;
using Repos.Tables;
using Services.Interfaces;

namespace Services.Tables;

public class CarSvc(ICarRepo repo) : IContributionSvc {
}