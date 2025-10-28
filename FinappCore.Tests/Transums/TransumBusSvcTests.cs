using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumBusSvcTests
{
    private readonly TransumCommonSvc<TransumBusDto, string> _transumBusSvc;

    public TransumBusSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException(TestConstants.ServiceProviderInitError);

        // Resolve DbContext first
        var dbContext = provider.GetRequiredService<AppDbContext>();

        // Use the static factory instead of the old TransumBusSvc
        _transumBusSvc = TransumServices.Bus(dbContext);
    }

    [Fact]
    public async Task GetUniqueBusinessesAsync_ReturnsNonEmptyList()
    {
        var businesses = await _transumBusSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(businesses);
        Assert.All(businesses, b => Assert.False(string.IsNullOrEmpty(b)));
    }

    [Fact]
    public async Task GetByBusiness_ReturnsBusiness()
    {
        var dto = await _transumBusSvc.FetchByKeyAsync("Ralph's");
        Assert.NotNull(dto);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumBusSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandom()
    {
        var dto = await _transumBusSvc.FetchRandomAsync();
        Assert.NotNull(dto);
    }
}