using Models.Tables.Shared;

namespace Models.Tables;

public class PaycheckTableDto
{
    // Shared/common fields
    public CommonTableDto Common { get; set; } = new();

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

    // Union / Benefits
    public decimal? AtDuesIbt { get; set; }
    public decimal? AtSuppDd { get; set; }
    public decimal? AtSuppLife { get; set; }
    public decimal? AtSurviveBen { get; set; }
    public decimal? DefComp457401a { get; set; }
    public decimal? PbDppoBTx { get; set; }
    public decimal? Fmla { get; set; }
    public decimal? PbKaiserBTax { get; set; }
    public decimal? PbLifeCoPd { get; set; }
    public decimal? PbPension { get; set; }
    public decimal? PbStDis { get; set; }
    public decimal? PbSurviveB { get; set; }
    public decimal? PbVisionGen { get; set; }
    public decimal? PbWcCler { get; set; }

    // Accruals
    public decimal? HolidayEarned { get; set; }
    public decimal? HolidayTaken { get; set; }
    public decimal? HolidayAdjust { get; set; }
    public decimal? HolidayCurrent { get; set; }
    public decimal? SickEarned { get; set; }
    public decimal? SickTaken { get; set; }
    public decimal? SickAdjust { get; set; }
    public decimal? SickCurrent { get; set; }
    public decimal? VacationEarned { get; set; }
    public decimal? VacationTaken { get; set; }
    public decimal? VacationAdjust { get; set; }
    public decimal? VacationCurrent { get; set; }
}
