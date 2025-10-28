using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumLocYrSvcTests
{
    private readonly TransumCommonSvc<TransumLocYrDto, object> _transumLocYrSvc;

    public TransumLocYrSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException(TestConstants.ServiceProviderInitError);

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _transumLocYrSvc = TransumServices.LocYr(dbContext);
    }

    [Fact]
    public async Task FetchAllUniqueKeysAsync_ReturnsNonEmptyList()
    {
        var keys = await _transumLocYrSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(keys);
        Assert.NotEmpty(keys);
    }

    [Fact]
    public async Task FetchByKeyAsync_ReturnsDto()
    {
        var key = new { City = "Los Angeles", State = "CA", Year = 2025 };
        var dto = await _transumLocYrSvc.FetchByKeyAsync(key);
        Assert.NotNull(dto);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositive()
    {
        var count = await _transumLocYrSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsDto()
    {
        var dto = await _transumLocYrSvc.FetchRandomAsync();
        Assert.NotNull(dto);
    }
}