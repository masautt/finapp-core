namespace Models.Transums;

public class TransumLocDto : TransumCommonDto
{
    // Primary key
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
}
