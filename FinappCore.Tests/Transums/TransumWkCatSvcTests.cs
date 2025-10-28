using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumWkCatSvcTests
{
    private readonly TransumCommonSvc<TransumWkCatDto, object> _transumWkCatSvc;

    public TransumWkCatSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException(TestConstants.ServiceProviderInitError);

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _transumWkCatSvc = TransumServices.WkCat(dbContext);
    }

    [Fact]
    public async Task GetUniqueWeekCategoriesAsync_ReturnsNonEmptyList()
    {
        var weekCategories = await _transumWkCatSvc.FetchAllUniqueKeysAsync();

        Assert.NotNull(weekCategories);
        Assert.NotEmpty(weekCategories);
    }

    [Fact]
    public async Task GetByWeekCategory_ReturnsWeekCategory()
    {
        var dto = await _transumWkCatSvc.FetchByKeyAsync(new { Week = 1, Category = "groceries" });

        Assert.NotNull(dto);
        Assert.Equal(1, dto.Week);
        Assert.Equal("groceries", dto.Category);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumWkCatSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandom()
    {
        var dto = await _transumWkCatSvc.FetchRandomAsync();

        Assert.NotNull(dto);
        Assert.True(dto.Week is >= 1 and <= 53);
        Assert.NotNull(dto.Category);
        Assert.NotEmpty(dto.Category);
    }
}