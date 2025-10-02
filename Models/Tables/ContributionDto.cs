namespace Models.Tables;

public class ContributionDto
{
    // Common fields
    public CommonDto Common { get; set; } = new();

    // Exact date fields
    public ExactDateFields Date { get; set; } = new();

    // Contribution-specific fields
    public decimal Amount { get; set; }
    public bool Exclude { get; set; }
    public string Account { get; set; } = null!;
}