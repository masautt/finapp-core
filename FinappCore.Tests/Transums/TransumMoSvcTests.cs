using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Services.Transums;
using Models.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumMoSvcTests
{
    private readonly TransumCommonSvc<TransumMoDto, string> _transumMoSvc;

    public TransumMoSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        // Resolve DbContext first
        var dbContext = provider.GetRequiredService<AppDbContext>();

        // Use the static factory instead of the old TransumMoSvc
        _transumMoSvc = TransumServices.Mo(dbContext);
    }

    [Fact]
    public async Task GetUniqueYearsAsync_ReturnsNonEmptyList()
    {
        var months = await _transumMoSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(months);
        Assert.All(months, m => Assert.False(string.IsNullOrEmpty(m)));
    }

    [Fact]
    public async Task GetByYear_ReturnsYearDto()
    {
        var dto = await _transumMoSvc.FetchByKeyAsync("jan");
        Assert.NotNull(dto);
        Assert.IsType<TransumMoDto>(dto);
        Assert.False(string.IsNullOrEmpty(dto.Month));
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumMoSvc.FetchTotalCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandomYearDto()
    {
        var dto = await _transumMoSvc.FetchRandomAsync();
        Assert.NotNull(dto);
        Assert.IsType<TransumMoDto>(dto);
        Assert.False(string.IsNullOrEmpty(dto.Month));
    }
}