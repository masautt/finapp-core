using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumYrCatSvcTests
{
    private readonly TransumCommonSvc<TransumYrCatDto, object> _transumYrCatSvc;

    public TransumYrCatSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        // Resolve DbContext first
        var dbContext = provider.GetRequiredService<AppDbContext>();

        // Use the static factory instead of the old TransumYrCatSvc
        _transumYrCatSvc = TransumServices.YrCat(dbContext);
    }

    [Fact]
    public async Task GetUniqueYrCatAsync_ReturnsNonEmptyList()
    {
        var yearCategories = await _transumYrCatSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(yearCategories);
    }

    [Fact]
    public async Task GetByYearCategory_ReturnsYrCat()
    {
        var key = new { Year = 2025, Category = "bills" };
        var dto = await _transumYrCatSvc.FetchByKeyAsync(key);
        Assert.NotNull(dto);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumYrCatSvc.FetchTotalCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandom()
    {
        var dto = await _transumYrCatSvc.FetchRandomAsync();
        Assert.NotNull(dto);
    }
}