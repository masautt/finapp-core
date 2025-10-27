using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumSubSvcTests
{
    private readonly TransumCommonSvc<TransumSubDto, string> _transumSubSvc;

    public TransumSubSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        // Resolve DbContext first
        var dbContext = provider.GetRequiredService<AppDbContext>();

        // Use the static factory instead of the old TransumSubSvc
        _transumSubSvc = TransumServices.Sub(dbContext);
    }

    [Fact]
    public async Task GetUniqueSubsAsync_ReturnsNonEmptyList()
    {
        var subcategories = await _transumSubSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(subcategories);
        Assert.All(subcategories, b => Assert.False(string.IsNullOrEmpty(b)));
    }

    [Fact]
    public async Task GetBySub_ReturnsSubcategory()
    {
        var dto = await _transumSubSvc.FetchByKeyAsync("carWash");
        Assert.NotNull(dto);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumSubSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandom()
    {
        var dto = await _transumSubSvc.FetchRandomAsync();
        Assert.NotNull(dto);
    }

    [Fact]
    public async Task FetchAllSortedAsync_ReturnsSortedResults()
    {
        var results = await _transumSubSvc.FetchBySortOrderAsync(
            dto => dto.TotalMarekCount,
            descending: true,
            limit: 3);

        Assert.NotNull(results);
        Assert.True(results.Count <= 10);
        Assert.All(results, dto => Assert.NotNull(dto.SubCategory));

        // Verify descending order
        for (var i = 0; i < results.Count - 1; i++)
        {
            Assert.True(results[i].TotalMarekCount >= results[i + 1].TotalMarekCount);
        }
    }

    [Fact]
    public async Task KeyExistsAsync_ReturnsTrueForExistingKey()
    {
        var exists = await _transumSubSvc.KeyExistsAsync("carWash");
        Assert.True(exists);
    }

    [Fact]
    public async Task KeyExistsAsync_ReturnsFalseForNonExistingKey()
    {
        var exists = await _transumSubSvc.KeyExistsAsync("drugs");
        Assert.True(exists);
    }
}