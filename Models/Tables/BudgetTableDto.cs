using Models.Tables.Shared;

namespace Models.Tables;

public class BudgetTableDto
{
    public CommonTableDto Common { get; set; } = new();

    public string Category { get; set; } = null!;
    public decimal Amount { get; set; }
}