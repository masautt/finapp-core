using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Services.Transums;
using Models.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumYrMoCatSvcTests
{
    private readonly TransumCommonSvc<TransumYrMoCatDto, object> _transumYrMoCatSvc;

    public TransumYrMoCatSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _transumYrMoCatSvc = TransumServices.YrMoCat(dbContext);
    }

    [Fact]
    public async Task GetUniqueYearMonthCategoriesAsync_ReturnsNonEmptyList()
    {
        var keys = await _transumYrMoCatSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(keys);
    }

    [Fact]
    public async Task GetByYearMonthCategory_ReturnsDto()
    {
        var key = new { Year = 2025, Month = "jan", Category = "bills" };
        var dto = await _transumYrMoCatSvc.FetchByKeyAsync(key);
        Assert.NotNull(dto);
        Assert.IsType<TransumYrMoCatDto>(dto);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumYrMoCatSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandomDto()
    {
        var dto = await _transumYrMoCatSvc.FetchRandomAsync();
        Assert.NotNull(dto);
        Assert.IsType<TransumYrMoCatDto>(dto);
    }
}
