namespace Database.Transums;

public static class TransumConstants
{
    // --- Transum Table Names ---
    public const string TransumBus = "transum_bus";
    public const string TransumBusYr = "transum_busyr";
    public const string TransumBusYrMo = "transum_busyrmo";

    public const string TransumCat = "transum_cat";
    public const string TransumCatSub = "transum_catsub";

    public const string TransumLoc = "transum_loc";
    public const string TransumLocYr = "transum_locyr";
    public const string TransumLocYrMo = "transum_locyrmo";

    public const string TransumMo = "transum_mo";
    public const string TransumSub = "transum_sub";
    public const string TransumWk = "transum_wk";
    public const string TransumWkCat = "transum_wkcat";
    public const string TransumWkCatSub = "transum_wkcatsub";

    public const string TransumYr = "transum_yr";
    public const string TransumYrCat = "transum_yrcat";
    public const string TransumYrCatSub = "transum_yrcatsub";
    public const string TransumYrMo = "transum_yrmo";
    public const string TransumYrMoCat = "transum_yrmocat";
    public const string TransumYrMoCatSub = "transum_yrmocatsub";
    public const string TransumYrMoDa = "transum_yrmoda";
    public const string TransumYrMoDaCat = "transum_yrmodacat";
    public const string TransumYrMoDaCatSub = "transum_yrmodacatsub";
    public const string TransumYrWk = "transum_yrwk";
    public const string TransumYrWkCat = "transum_yrwkcat";
    public const string TransumYrWkCatSub = "transum_yrwkcatsub";

    // --- Primary Key Columns ---
    public const string Category = "category";
    public const string Business = "business";
    public const string SubCategory = "sub_category";
    public const string City = "city";
    public const string State = "state";
    public const string Year = "year";
    public const string Month = "month";
    public const string Week = "week";
    public const string Day = "day";

    // --- Overall Totals ---
    public const string TotalAmount = "total_amount";
    public const string TotalCount = "total_count";
    public const string AverageAmount = "average_amount";

    // --- Ex / NonEx Breakdowns ---
    public const string TotalExAmount = "total_ex_amount";
    public const string TotalExCount = "total_ex_count";
    public const string AverageExAmount = "average_ex_amount";

    public const string TotalNonExAmount = "total_nonex_amount";
    public const string TotalNonExCount = "total_nonex_count";
    public const string AverageNonExAmount = "average_nonex_amount";

    // --- Necessity Breakdowns ---
    public const string TotalWantAmount = "total_want_amount";
    public const string TotalWantCount = "total_want_count";
    public const string AverageWantAmount = "average_want_amount";

    public const string TotalNeedAmount = "total_need_amount";
    public const string TotalNeedCount = "total_need_count";
    public const string AverageNeedAmount = "average_need_amount";

    // --- Recipient Breakdowns ---
    public const string TotalMarekAmount = "total_marek_amount";
    public const string TotalMarekCount = "total_marek_count";
    public const string AverageMarekAmount = "average_marek_amount";

    public const string TotalLisaAmount = "total_lisa_amount";
    public const string TotalLisaCount = "total_lisa_count";
    public const string AverageLisaAmount = "average_lisa_amount";

    public const string TotalOtherAmount = "total_other_amount";
    public const string TotalOtherCount = "total_other_count";
    public const string AverageOtherAmount = "average_other_amount";

    public const string TotalPetAmount = "total_pet_amount";
    public const string TotalPetCount = "total_pet_count";
    public const string AveragePetAmount = "average_pet_amount";
}
