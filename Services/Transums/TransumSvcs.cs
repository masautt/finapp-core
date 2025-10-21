using Database;
using Models.Transums;
using Repos.Transums;

namespace Services.Transums;

public static class TransumServices
{
    public static TransumCommonSvc<TransumBusDto, string> Bus(AppDbContext db) =>
        new(new TransumCommonRepo<TransumBusDto, string>(db, t => t.Business));

    public static TransumCommonSvc<TransumCatDto, string> Cat(AppDbContext db) =>
        new(new TransumCommonRepo<TransumCatDto, string>(db, t => t.Category));

    public static TransumCommonSvc<TransumLocDto, object> Loc(AppDbContext db) =>
        new(new TransumCommonRepo<TransumLocDto, object>(db, t => new { t.City, t.State }));

    public static TransumCommonSvc<TransumMoDto, string> Mo(AppDbContext db) =>
        new(new TransumCommonRepo<TransumMoDto, string>(db, t => t.Month));

    public static TransumCommonSvc<TransumSubDto, string> Sub(AppDbContext db) =>
        new(new TransumCommonRepo<TransumSubDto, string>(db, t => t.SubCategory));

    public static TransumCommonSvc<TransumYrCatDto, object> YrCat(AppDbContext db) =>
        new(new TransumCommonRepo<TransumYrCatDto, object>(db, t => new { t.Year, t.Category }));

    public static TransumCommonSvc<TransumYrDto, int> Yr(AppDbContext db) =>
        new(new TransumCommonRepo<TransumYrDto, int>(db, t => t.Year));
    public static TransumCommonSvc<TransumYrMoDto, object> YrMo(AppDbContext db) =>
        new(new TransumCommonRepo<TransumYrMoDto, object>(db, t => new { t.Year, t.Month }));

    public static TransumCommonSvc<TransumYrMoCatDto, object> YrMoCat(AppDbContext db) =>
        new(new TransumCommonRepo<TransumYrMoCatDto, object>(db, t => new { t.Year, t.Month, t.Category }));

    public static TransumCommonSvc<TransumYrMoDaDto, object> YrMoDa(AppDbContext db) =>
        new(new TransumCommonRepo<TransumYrMoDaDto, object>(db, t => new { t.Year, t.Month, t.Day }));

    public static TransumCommonSvc<TransumYrMoDaCatDto, object> YrMoDaCat(AppDbContext db) =>
        new(new TransumCommonRepo<TransumYrMoDaCatDto, object>(db, t => new { t.Year, t.Month, t.Day, t.Category }));

    public static TransumCommonSvc<TransumYrMoDaCatSubDto, object> YrMoDaCatSub(AppDbContext db) =>
        new(new TransumCommonRepo<TransumYrMoDaCatSubDto, object>(db, t => new { t.Year, t.Month, t.Day, t.Category, t.SubCategory }));
}
