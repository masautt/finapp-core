using Models.Tables;
using Repos.Tables.Shared;
using Services.Tables.Interfaces;
using Services.Tables.Shared;

namespace Services.Tables;

public class PaycheckSvc(EntityRepo entityRepo)
    : EntitySvc<PaycheckDto>(entityRepo), IPaycheckSvc
{
    public async Task<object?> GetLatestTimeOff()
    {
        var lastPaycheck = await FetchLatestRecord();
        if (lastPaycheck == null) return null;

        return new
        {
            lastPaycheck.HolidayCurrent,
            lastPaycheck.SickCurrent,
            lastPaycheck.VacationCurrent
        };
    }
}