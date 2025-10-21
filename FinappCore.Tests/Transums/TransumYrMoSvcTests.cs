using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Services.Transums;
using Models.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumYrMoSvcTests
{
    private readonly TransumCommonSvc<TransumYrMoDto, object> _transumYrMoSvc;

    public TransumYrMoSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _transumYrMoSvc = TransumServices.YrMo(dbContext); // returns object key
    }

    [Fact]
    public async Task GetUniqueYearMonthsAsync_ReturnsNonEmptyList()
    {
        var yearMonths = await _transumYrMoSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(yearMonths);
    }

    [Fact]
    public async Task GetByYearMonth_ReturnsDto()
    {
        var key = new { Year = 2025, Month = "jan" }; // composite key
        var dto = await _transumYrMoSvc.FetchByKeyAsync(key);
        Assert.NotNull(dto);
        Assert.IsType<TransumYrMoDto>(dto);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumYrMoSvc.FetchTotalCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandomDto()
    {
        var dto = await _transumYrMoSvc.FetchRandomAsync();
        Assert.NotNull(dto);
        Assert.IsType<TransumYrMoDto>(dto);
    }
}