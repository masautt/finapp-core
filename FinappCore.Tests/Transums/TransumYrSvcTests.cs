using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Services.Transums;
using Models.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumYrSvcTests
{
    private readonly TransumYrSvc _transumYrSvc;

    public TransumYrSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        _transumYrSvc = provider.GetRequiredService<TransumYrSvc>();
    }

    [Fact]
    public async Task GetUniqueYearsAsync_ReturnsNonEmptyList()
    {
        var years = await _transumYrSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(years);
        Assert.All(years, y => Assert.False(string.IsNullOrEmpty(y)));
    }

    [Fact]
    public async Task GetByYear_ReturnsYearDto()
    {
        var dto = await _transumYrSvc.FetchByKeyAsync("2025");
        Assert.NotNull(dto);
        Assert.IsType<TransumYrDto>(dto);
        Assert.False(string.IsNullOrEmpty(dto.Year));
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumYrSvc.FetchTotalCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandomYearDto()
    {
        var dto = await _transumYrSvc.FetchRandomAsync();
        Assert.NotNull(dto);
        Assert.IsType<TransumYrDto>(dto);
        Assert.False(string.IsNullOrEmpty(dto.Year));
    }
}