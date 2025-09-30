using Models;

public class SideGigDto
{
    public CommonDto Common { get; set; } = new();
    public DateRangeFields DateRange { get; set; } = new();

    public decimal? HoursWorked { get; set; }
    public decimal AmountPaid { get; set; }
    public string Company { get; set; } = null!;
}