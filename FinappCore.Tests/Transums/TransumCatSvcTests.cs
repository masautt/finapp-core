using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumCatSvcTests
{
    private readonly TransumCatSvc _transumCatSvc;

    public TransumCatSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        _transumCatSvc = provider.GetRequiredService<TransumCatSvc>();
    }

    [Fact]
    public async Task GetCategoriesAsync_ReturnsNonEmptyList()
    {
        var categories = await _transumCatSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(categories);
        Assert.All(categories, c => Assert.False(string.IsNullOrEmpty(c)));
    }

    [Fact]
    public async Task GetByCategoryAsync_ReturnsCategory()
    {
        var dto = await _transumCatSvc.FetchByKeyAsync("groceries");
        Assert.NotNull(dto);
    }
}