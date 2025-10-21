using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Services.Views;

namespace FinappCore.Tests.Views;

[Collection(TestConstants.TestCollectionName)]
public class DropdownSvcTests
{
    private readonly DropdownSvc _dropdownSvc;

    public DropdownSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _dropdownSvc = new DropdownSvc(dbContext);
    }

    [Fact]
    public async Task FetchAllBusinessesAsync_ReturnsNonEmptyList()
    {
        var result = await _dropdownSvc.FetchAllBusinessesAsync();
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task FetchAllCategoriesAsync_ReturnsNonEmptyList()
    {
        var result = await _dropdownSvc.FetchAllCategoriesAsync();
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task FetchAllSubcategoriesAsync_ReturnsNonEmptyList()
    {
        var result = await _dropdownSvc.FetchAllSubcategoriesAsync();
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task FetchAllLocationsAsync_ReturnsNonEmptyList()
    {
        var result = await _dropdownSvc.FetchAllLocationsAsync();
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task FetchAllMonthsAsync_ReturnsNonEmptyList()
    {
        var result = await _dropdownSvc.FetchAllMonthsAsync();
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task FetchAllYearsAsync_ReturnsNonEmptyList()
    {
        var result = await _dropdownSvc.FetchAllYearsAsync();
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
}