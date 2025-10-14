using Microsoft.Extensions.DependencyInjection;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection("Database")]
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
        var categories = await _transumCatSvc.GetCategoriesAsync();
        Assert.NotNull(categories);
        Assert.All(categories, c => Assert.False(string.IsNullOrEmpty(c)));
    }

    [Fact]
    public async Task GetByCategoryAsync_ReturnsCategory()
    {
        var dto = await _transumCatSvc.GetByCategoryAsync("groceries");
        Assert.NotNull(dto);
    }
}