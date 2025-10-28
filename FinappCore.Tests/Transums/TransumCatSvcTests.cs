using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumCatSvcTests
{
    private readonly TransumCommonSvc<TransumCatDto, string> _transumCatSvc;

    public TransumCatSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException(TestConstants.ServiceProviderInitError);

        // Resolve DbContext first
        var dbContext = provider.GetRequiredService<AppDbContext>();

        // Use the static factory instead of the old TransumCatSvc
        _transumCatSvc = TransumServices.Cat(dbContext);
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