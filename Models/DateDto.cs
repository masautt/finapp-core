namespace Models;

public class DateRangeFields
{
    public DateTime StartDate { get; set; }
    public string Month { get; set; } = null!;
    public int Year { get; set; }
    public DateTime EndDate { get; set; }
}

public class ExactDateFields
{
    public int Year { get; set; }
    public string Month { get; set; } = null!;
    public int Day { get; set; }
    public string Weekday { get; set; } = null!;
    public DateTime Date { get; set; }
}
