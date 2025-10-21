namespace Models.Transums;

public class TransumBusDto : TransumCommonDto
{
    public string Business { get; set; } = null!;
}

public class TransumCatDto : TransumCommonDto
{
    public string Category { get; set; } = null!;
}

public class TransumLocDto : TransumCommonDto
{
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
}

public class TransumMoDto : TransumCommonDto
{
    public string Month { get; set; } = null!;
}

public class TransumSubDto : TransumCommonDto
{
    public string SubCategory { get; set; } = null!;
}

public class TransumYrCatDto : TransumCommonDto
{
    public int Year { get; set; }
    public string Category { get; set; } = null!;
}

public class TransumYrDto : TransumCommonDto
{
    public int Year { get; set; }
}

public class TransumYrMoDto : TransumCommonDto
{
    public int Year { get; set; }
    public string Month { get; set; } = null!;
}

public class TransumYrMoCatDto : TransumCommonDto
{
    public int Year { get; set; }
    public string Month { get; set; } = null!;
    public string Category { get; set; } = null!;
}

public class TransumYrMoDaDto : TransumCommonDto
{
    public int Year { get; set; }
    public string Month { get; set; } = null!;
    public int Day { get; set; }
}

public class TransumYrMoDaCatDto : TransumCommonDto
{
    public int Year { get; set; }
    public string Month { get; set; } = null!;
    public int Day { get; set; }
    public string Category { get; set; } = null!;
}

public class TransumYrMoDaCatSubDto : TransumCommonDto
{
    public int Year { get; set; }
    public string Month { get; set; } = null!;
    public int Day { get; set; }
    public string Category { get; set; } = null!;
    public string SubCategory { get; set; } = null!;
}