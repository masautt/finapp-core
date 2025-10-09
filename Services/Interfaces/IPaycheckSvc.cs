using Models.Tables;

namespace Services.Interfaces;

public interface IPaycheckSvc : IEntitySvc<PaycheckDto>
{
    Task<object?> GetLatestTimeOff();
}