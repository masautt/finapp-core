namespace Models.Tables;

public class PaycheckDto
{
    // Shared/common fields
    public CommonDto Common { get; set; } = new();

    // Date range
    public DateRangeFields DateRange { get; set; } = new();

    // Paycheck-specific fields
    public string Source { get; set; } = string.Empty;
    public DateTime CheckDate { get; set; }
    public decimal? HoursPaid { get; set; }
    public decimal? PayRate { get; set; }
    public decimal? OvertimeHours { get; set; }
    public decimal? HolidayUsed { get; set; }
    public decimal? FixedFloatingHoliday { get; set; }
    public decimal? GrossEarnings { get; set; }
    public decimal? TaxableGross { get; set; }
    public decimal? TotalTaxes { get; set; }
    public decimal? TotalDeductions { get; set; }
    public decimal? NetPay { get; set; }
    public decimal? StateTax { get; set; }
    public decimal? MedicareTax { get; set; }
    public decimal? FedTax { get; set; }
    public decimal? DeferredComp { get; set; }
    public decimal? DentalInsurance { get; set; }
    public decimal? MedicalInsurance { get; set; }
    public decimal? PensionCont { get; set; }
    public decimal? RetireeTrust { get; set; }
}