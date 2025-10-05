using Models.Tables;
using Repos.Interfaces;
using Repos.Shared;
using Services.Interfaces;
using Services.Shared;

namespace Services.Tables;

public class PaycheckSvc(IPaycheckRepo repo, CommonRepo commonRepo)
    : CommonSvc<PaycheckDto>(commonRepo), IPaycheckSvc
{
    private readonly IPaycheckRepo _repo = repo;

    public async Task<object?> GetLatestTimeOff()
    {
        var lastPaycheck = await GetLastRecord();

        if (lastPaycheck == null) return null;

        return new
        {
            lastPaycheck.HolidayCurrent,
            lastPaycheck.SickCurrent,
            lastPaycheck.VacationCurrent
        };
    }
}
