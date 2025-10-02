namespace Models.Tables;

public class InvestmentDto
{
    // Common fields
    public CommonDto Common { get; set; } = new();

    // Date range fields
    public DateRangeFields Date { get; set; } = new();

    // Investment-specific fields
    public decimal? BeginningBalance { get; set; }
    public decimal? EndingBalance { get; set; }
    public decimal? ChangeInValue { get; set; }
    public decimal? ChangeInPercentage { get; set; }
    public string Type { get; set; } = null!;

}