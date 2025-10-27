using Models.Tables;
using Models.Tables.Shared;

namespace Models.Views;

public class CarMileageSpendingDto
{
    public decimal? StartMiles { get; set; }
    public decimal? MilesAdded { get; set; }
    public DateRangeFields DateRange { get; set; } = new();

    // Derived/calculated values
    public decimal? AvgMilesPerMonth { get; set; }
    public decimal? GasMoneySpent { get; set; }
}