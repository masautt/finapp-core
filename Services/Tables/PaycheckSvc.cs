using Models.Tables;
using Repos.Shared;
using Services.Interfaces;
using Services.Shared;

namespace Services.Tables;

public class PaycheckSvc(EntityRepo entityRepo)
    : EntitySvc<PaycheckDto>(entityRepo), IPaycheckSvc
{
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