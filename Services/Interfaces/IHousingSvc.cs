using Models.Tables;
using Services.Tables;

namespace Services.Interfaces;

public interface IHousingSvc : IEntitySvc<HousingDto>
{
    Task<List<HousingSvc.UtilityRecord>> FetchUtilities();
}