using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumLocYrMoSvcTests
{
    private readonly TransumCommonSvc<TransumLocYrMoDto, object> _transumLocYrMoSvc;

    public TransumLocYrMoSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException(TestConstants.ServiceProviderInitError);

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _transumLocYrMoSvc = TransumServices.LocYrMo(dbContext);
    }

    [Fact]
    public async Task FetchAllUniqueKeysAsync_ReturnsNonEmptyList()
    {
        var keys = await _transumLocYrMoSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(keys);
        Assert.NotEmpty(keys);
    }

    [Fact]
    public async Task FetchByKeyAsync_ReturnsDto()
    {
        var key = new { City = "Los Angeles", State = "CA", Year = 2025, Month = "Jan" };
        var dto = await _transumLocYrMoSvc.FetchByKeyAsync(key);
        Assert.NotNull(dto);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositive()
    {
        var count = await _transumLocYrMoSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsDto()
    {
        var dto = await _transumLocYrMoSvc.FetchRandomAsync();
        Assert.NotNull(dto);
    }
}