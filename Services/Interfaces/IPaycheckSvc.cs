using Models.Tables;

namespace Services.Interfaces;

public interface IPaycheckSvc : ICommonSvc<PaycheckDto>
{
    Task<object?> GetLatestTimeOff();
}