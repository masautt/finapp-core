namespace Models.Transums;

public class TransumCommonDto
{
    // Overall totals
    public decimal TotalAmount { get; set; }
    public int TotalCount { get; set; }
    public decimal AverageAmount { get; set; }

    // Ex / Non-Ex breakdowns
    public decimal TotalExAmount { get; set; }
    public int TotalExCount { get; set; }
    public decimal AverageExAmount { get; set; }

    public decimal TotalNonExAmount { get; set; }
    public int TotalNonExCount { get; set; }
    public decimal AverageNonExAmount { get; set; }

    // Necessity breakdowns
    public decimal TotalWantAmount { get; set; }
    public int TotalWantCount { get; set; }
    public decimal AverageWantAmount { get; set; }

    public decimal TotalNeedAmount { get; set; }
    public int TotalNeedCount { get; set; }
    public decimal AverageNeedAmount { get; set; }

    // Recipient breakdowns
    public decimal TotalMarekAmount { get; set; }
    public int TotalMarekCount { get; set; }
    public decimal AverageMarekAmount { get; set; }

    public decimal TotalLisaAmount { get; set; }
    public int TotalLisaCount { get; set; }
    public decimal AverageLisaAmount { get; set; }

    public decimal TotalOtherAmount { get; set; }
    public int TotalOtherCount { get; set; }
    public decimal AverageOtherAmount { get; set; }

    public decimal TotalPetAmount { get; set; }
    public int TotalPetCount { get; set; }
    public decimal AveragePetAmount { get; set; }
}