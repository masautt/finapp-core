using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Services.Transums;
using Models.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumYrMoDaSvcTests
{
    private readonly TransumCommonSvc<TransumYrMoDaDto, object> _transumYrMoDaSvc;

    public TransumYrMoDaSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _transumYrMoDaSvc = TransumServices.YrMoDa(dbContext);
    }

    [Fact]
    public async Task GetUniqueYearMonthDaysAsync_ReturnsNonEmptyList()
    {
        var keys = await _transumYrMoDaSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(keys);
    }

    [Fact]
    public async Task GetByYearMonthDay_ReturnsDto()
    {
        var key = new { Year = 2025, Month = "jan", Day = 1 };
        var dto = await _transumYrMoDaSvc.FetchByKeyAsync(key);
        Assert.NotNull(dto);
        Assert.IsType<TransumYrMoDaDto>(dto);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumYrMoDaSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandomDto()
    {
        var dto = await _transumYrMoDaSvc.FetchRandomAsync();
        Assert.NotNull(dto);
        Assert.IsType<TransumYrMoDaDto>(dto);
    }
}
