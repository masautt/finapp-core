using Database;
using Services.Transums;

namespace Services.Views;

public class DropdownSvc(AppDbContext db)
{
    public Task<List<string>> FetchAllBusinessesAsync()
    {
        var service = TransumServices.Bus(db);
        return service.FetchAllUniqueKeysAsync();
    }

    public Task<List<string>> FetchAllCategoriesAsync()
    {
        var service = TransumServices.Cat(db);
        return service.FetchAllUniqueKeysAsync();
    }

    public Task<List<string>> FetchAllSubcategoriesAsync()
    {
        var service = TransumServices.Sub(db);
        return service.FetchAllUniqueKeysAsync();
    }

    public Task<List<object>> FetchAllLocationsAsync()
    {
        var service = TransumServices.Loc(db);
        return service.FetchAllUniqueKeysAsync();
    }

    public Task<List<string>> FetchAllMonthsAsync()
    {
        var service = TransumServices.Mo(db);
        return service.FetchAllUniqueKeysAsync();
    }

    public Task<List<int>> FetchAllYearsAsync()
    {
        var service = TransumServices.Yr(db);
        return service.FetchAllUniqueKeysAsync();
    }
}