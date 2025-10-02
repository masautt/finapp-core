namespace Models.Tables;

public class BudgetDto
{
    public CommonDto Common { get; set; } = new();

    public string Category { get; set; } = null!;
    public decimal Amount { get; set; }
}