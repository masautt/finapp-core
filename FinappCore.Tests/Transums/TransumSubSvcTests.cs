using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumSubSvcTests
{
    private readonly TransumSubSvc _transumSubSvc;

    public TransumSubSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        _transumSubSvc = provider.GetRequiredService<TransumSubSvc>();
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
        var count = await _transumSubSvc.FetchTotalCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandom()
    {
        var dto = await _transumSubSvc.FetchRandomAsync();
        Assert.NotNull(dto);
    }
}