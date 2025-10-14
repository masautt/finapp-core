using Models.Tables;

namespace Services.Tables.Interfaces;

public interface IPaycheckSvc : IEntitySvc<PaycheckDto>
{
    Task<object?> GetLatestTimeOff();
}