using Models.Tables.Shared;

namespace Models.Tables;

public class CarTableDto
{
    // Shared/common fields
    public CommonTableDto Common { get; set; } = new();

    // Date range
    public DateRangeFields DateRange { get; set; } = new();

    // Car-specific fields
    public DateTime PaymentDate { get; set; }
    public decimal? PaymentAmount { get; set; }
    public decimal? Principal { get; set; }
    public decimal? Interest { get; set; }
    public decimal? Owed { get; set; }
    public decimal? InsuranceAmount { get; set; }
    public DateTime? InsuranceDate { get; set; }
    public decimal? StartMiles { get; set; }
    public decimal? MilesAdded { get; set; }
    public DateTime? MilesDate { get; set; }
}
