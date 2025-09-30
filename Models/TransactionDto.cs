namespace Models;

public class TransactionDto
{
    // Common fields
    public CommonDto Common { get; set; } = new();

    // Exact date fields
    public ExactDateFields Date { get; set; } = new();

    // Transaction-specific fields
    public string Category { get; set; } = null!;
    public string SubCategory { get; set; } = "(none)";
    public decimal Amount { get; set; }
    public string Business { get; set; } = null!;
    public string City { get; set; } = "(none)";
    public string State { get; set; } = "(none)";
    public string? Description { get; set; }
    public string? Comments { get; set; }
    public string Recipient { get; set; } = null!;
    public string Necessity { get; set; } = null!;
    public string Reimburse { get; set; } = "(none)";
    public string Recurring { get; set; } = "(none)";
    public bool Ex { get; set; } = false;
}