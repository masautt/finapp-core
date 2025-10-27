namespace Models.Transums
{
    public class TransumBusDto : TransumCommonDto
    {
        public string Business { get; set; } = null!;
    }

    public class TransumCatDto : TransumCommonDto
    {
        public string Category { get; set; } = null!;
    }

    public class TransumCatSubDto : TransumCommonDto
    {
        public string Category { get; set; } = null!;
        public string SubCategory { get; set; } = null!;
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

    public class TransumWkDto : TransumCommonDto
    {
        public int Week { get; set; }
    }

    public class TransumWkCatDto : TransumCommonDto
    {
        public int Week { get; set; }
        public string Category { get; set; } = null!;
    }

    public class TransumWkCatSubDto : TransumCommonDto
    {
        public int Week { get; set; }
        public string Category { get; set; } = null!;
        public string SubCategory { get; set; } = null!;
    }

    public class TransumYrDto : TransumCommonDto
    {
        public int Year { get; set; }
    }

    public class TransumYrCatDto : TransumCommonDto
    {
        public int Year { get; set; }
        public string Category { get; set; } = null!;
    }

    public class TransumYrCatSubDto : TransumCommonDto
    {
        public int Year { get; set; }
        public string Category { get; set; } = null!;
        public string SubCategory { get; set; } = null!;
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

    public class TransumYrMoCatSubDto : TransumCommonDto
    {
        public int Year { get; set; }
        public string Month { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string SubCategory { get; set; } = null!;
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

    public class TransumYrWkDto : TransumCommonDto
    {
        public int Year { get; set; }
        public int Week { get; set; }
    }

    public class TransumYrWkCatDto : TransumCommonDto
    {
        public int Year { get; set; }
        public int Week { get; set; }
        public string Category { get; set; } = null!;
    }

    public class TransumYrWkCatSubDto : TransumCommonDto
    {
        public int Year { get; set; }
        public int Week { get; set; }
        public string Category { get; set; } = null!;
        public string SubCategory { get; set; } = null!;
    }
}
