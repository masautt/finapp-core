using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumBusYrMoSvcTests
{
    private readonly TransumCommonSvc<TransumBusYrMoDto, object> _transumBusYrMoSvc;

    public TransumBusYrMoSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException(TestConstants.ServiceProviderInitError);

        // Resolve DbContext first
        var dbContext = provider.GetRequiredService<AppDbContext>();

        // Use the static factory instead of the old TransumBusSvc
        _transumBusYrMoSvc = TransumServices.BusYrMo(dbContext);
    }

    [Fact]
    public async Task FetchAllUniqueKeysAsync_ReturnsNonEmptyList()
    {
        var keys = await _transumBusYrMoSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(keys);
        Assert.NotEmpty(keys);
    }

    [Fact]
    public async Task FetchByKeyAsync_ReturnsDto()
    {
        var key = new { Business = "Amazon" };
        var dto = await _transumBusYrMoSvc.FetchByPartialKeyAsync(key);
        Assert.NotNull(dto);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositive()
    {
        var count = await _transumBusYrMoSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsDto()
    {
        var dto = await _transumBusYrMoSvc.FetchRandomAsync();
        Assert.NotNull(dto);
    }
}