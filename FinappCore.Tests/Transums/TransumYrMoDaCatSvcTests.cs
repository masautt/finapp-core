using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Services.Transums;
using Models.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumYrMoDaCatSvcTests
{
    private readonly TransumCommonSvc<TransumYrMoDaCatDto, object> _transumYrMoDaCatSvc;

    public TransumYrMoDaCatSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException(TestConstants.ServiceProviderInitError);

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _transumYrMoDaCatSvc = TransumServices.YrMoDaCat(dbContext);
    }

    [Fact]
    public async Task GetUniqueKeysAsync_ReturnsNonEmptyList()
    {
        var keys = await _transumYrMoDaCatSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(keys);
    }

    [Fact]
    public async Task GetByKey_ReturnsDto()
    {
        var key = new { Year = 2025, Month = "jan", Day = 1, Category = "bills" };
        var dto = await _transumYrMoDaCatSvc.FetchByKeyAsync(key);
        Assert.NotNull(dto);
        Assert.IsType<TransumYrMoDaCatDto>(dto);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumYrMoDaCatSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandomDto()
    {
        var dto = await _transumYrMoDaCatSvc.FetchRandomAsync();
        Assert.NotNull(dto);
        Assert.IsType<TransumYrMoDaCatDto>(dto);
    }
}
