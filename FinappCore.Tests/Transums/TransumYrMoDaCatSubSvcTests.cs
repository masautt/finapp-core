using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Services.Transums;
using Models.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumYrMoDaCatSubSvcTests
{
    private readonly TransumCommonSvc<TransumYrMoDaCatSubDto, object> _transumYrMoDaCatSubSvc;

    public TransumYrMoDaCatSubSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _transumYrMoDaCatSubSvc = TransumServices.YrMoDaCatSub(dbContext);
    }

    [Fact]
    public async Task GetUniqueKeysAsync_ReturnsNonEmptyList()
    {
        var keys = await _transumYrMoDaCatSubSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(keys);
    }

    [Fact]
    public async Task GetByKey_ReturnsDto()
    {
        var key = new { Year = 2022, Month = "apr", Day = 2, Category = "eatingout", SubCategory = "coffeeShop" };
        var dto = await _transumYrMoDaCatSubSvc.FetchByKeyAsync(key);
        Assert.NotNull(dto);
        Assert.IsType<TransumYrMoDaCatSubDto>(dto);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumYrMoDaCatSubSvc.FetchTotalCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandomDto()
    {
        var dto = await _transumYrMoDaCatSubSvc.FetchRandomAsync();
        Assert.NotNull(dto);
        Assert.IsType<TransumYrMoDaCatSubDto>(dto);
    }
}