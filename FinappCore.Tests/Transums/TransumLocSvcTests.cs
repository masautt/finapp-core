using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumLocSvcTests
{
    private readonly TransumCommonSvc<TransumLocDto, object> _transumLocSvc;

    public TransumLocSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        // Resolve DbContext first
        var dbContext = provider.GetRequiredService<AppDbContext>();

        // Use the static factory instead of the old TransumLocSvc
        _transumLocSvc = TransumServices.Loc(dbContext);
    }

    [Fact]
    public async Task GetUniqueLocationsAsync_ReturnsNonEmptyList()
    {
        var locations = await _transumLocSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(locations);
    }

    [Fact]
    public async Task GetByLocation_ReturnsLocation()
    {
        var key = new { City = "Los Angeles", State = "CA" };
        var dto = await _transumLocSvc.FetchByKeyAsync(key);
        Assert.NotNull(dto);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumLocSvc.FetchTotalCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandom()
    {
        var dto = await _transumLocSvc.FetchRandomAsync();
        Assert.NotNull(dto);
    }
}