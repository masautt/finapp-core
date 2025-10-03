using Models.Tables;
using Services.Interfaces;
using Services.Shared;

namespace Services.Tables;

public class PaycheckSvc(CommonSvc commonSvc) : IPaycheckSvc
{

    public async Task<object?> GetLatestTimeOff()
    {
        var lastPaycheck = await commonSvc.GetLastRecord<PaycheckDto>(p => p.Common.Number);

        if (lastPaycheck == null)
            return null;

        return new
        {
            lastPaycheck.HolidayCurrent,
            lastPaycheck.SickCurrent,
            lastPaycheck.VacationCurrent
        };
    }
}