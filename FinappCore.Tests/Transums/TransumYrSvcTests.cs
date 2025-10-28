using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Services.Transums;
using Models.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumYrSvcTests
{
    private readonly TransumCommonSvc<TransumYrDto, int> _transumYrSvc;

    public TransumYrSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException(TestConstants.ServiceProviderInitError);

        // Resolve DbContext first
        var dbContext = provider.GetRequiredService<AppDbContext>();

        // Use the static factory instead of the old TransumYrSvc
        _transumYrSvc = TransumServices.Yr(dbContext);
    }

    [Fact]
    public async Task GetUniqueYearsAsync_ReturnsNonEmptyList()
    {
        var years = await _transumYrSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(years);
    }

    [Fact]
    public async Task GetByYear_ReturnsYearDto()
    {
        var dto = await _transumYrSvc.FetchByKeyAsync(2025);
        Assert.NotNull(dto);
        Assert.IsType<TransumYrDto>(dto);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumYrSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandomYearDto()
    {
        var dto = await _transumYrSvc.FetchRandomAsync();
        Assert.NotNull(dto);
        Assert.IsType<TransumYrDto>(dto);
    }
}