using Models.Tables;
using Repos.Interfaces;
using Repos.Shared;
using Services.Interfaces;
using Services.Shared;

namespace Services.Tables;

public class CarSvc(ICarRepo repo, CommonRepo commonRepo)
    : CommonSvc(commonRepo), ICarSvc
{
    private readonly ICarRepo _repo = repo;

    // Car-specific methods can use _repo
}