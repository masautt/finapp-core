using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumBusYrSvcTests
{
    private readonly TransumCommonSvc<TransumBusYrDto, object> _transumBusYrSvc;

    public TransumBusYrSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException(TestConstants.ServiceProviderInitError);

        // Resolve DbContext first
        var dbContext = provider.GetRequiredService<AppDbContext>();

        // Use the static factory instead of the old TransumBusSvc
        _transumBusYrSvc = TransumServices.BusYr(dbContext);
    }

    [Fact]
    public async Task FetchAllUniqueKeysAsync_ReturnsNonEmptyList()
    {
        var keys = await _transumBusYrSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(keys);
        Assert.NotEmpty(keys);
    }

    [Fact]
    public async Task FetchByKeyAsync_ReturnsDto()
    {
        var key = new { Business = "Amazon"};
        var dto = await _transumBusYrSvc.FetchByPartialKeyAsync(key);
        Assert.NotNull(dto);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositive()
    {
        var count = await _transumBusYrSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsDto()
    {
        var dto = await _transumBusYrSvc.FetchRandomAsync();
        Assert.NotNull(dto);
    }
}