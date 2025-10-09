using Models.Tables;
using Repos.Shared;
using Services.Interfaces;
using Services.Shared;

namespace Services.Tables;

public class HousingSvc(EntityRepo entityRepo) : EntitySvc<HousingDto>(entityRepo), IHousingSvc
{
    public async Task<List<UtilityRecord>> FetchUtilities()
    {
        return await FetchProjected(
            h => new UtilityRecord
            {
                UtilitiesDate = h.UtilitiesDate!.Value,
                Electricity = h.Electricity ?? 0,
                Water = h.Water ?? 0,
                Gas = h.Gas ?? 0,
                Wifi = h.Wifi ?? 0,
                CityServices = h.CityServices ?? 0,
                TotalUtilities = h.TotalUtilities
            },
            h => h.UtilitiesDate != null
        );
    }

    public class UtilityRecord
    {
        public DateTime UtilitiesDate { get; set; }
        public decimal Electricity { get; set; }
        public decimal Water { get; set; }
        public decimal Gas { get; set; }
        public decimal Wifi { get; set; }
        public decimal CityServices { get; set; }
        public decimal TotalUtilities { get; set; }
    }
}