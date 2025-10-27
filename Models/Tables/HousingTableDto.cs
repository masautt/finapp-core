using Models.Tables.Shared;

namespace Models.Tables;

public class HousingTableDto
{
    // Shared/common fields
    public CommonTableDto Common { get; set; } = new();

    // Date range
    public DateRangeFields DateRange { get; set; } = new();

    // Housing-specific fields
    public decimal RentAmount { get; set; }
    public DateTime RentDate { get; set; }
    public decimal? InsuranceAmount { get; set; }
    public DateTime? InsuranceDate { get; set; }
    public decimal? PetRent { get; set; }
    public decimal? Fees { get; set; }
    public DateTime? UtilitiesDate { get; set; }
    public decimal? Electricity { get; set; }
    public decimal? Water { get; set; }
    public decimal? Gas { get; set; }
    public decimal? Wifi { get; set; }
    public decimal? CityServices { get; set; }
    public decimal TotalUtilities { get; set; }
    public decimal TotalHousing { get; set; }
}