using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumWkCatSubSvcTests
{
    private readonly TransumCommonSvc<TransumWkCatSubDto, object> _transumWkCatSubSvc;

    public TransumWkCatSubSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException(TestConstants.ServiceProviderInitError);

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _transumWkCatSubSvc = TransumServices.WkCatSub(dbContext);
    }

    [Fact]
    public async Task GetUniqueWeekCategorySubCategoriesAsync_ReturnsNonEmptyList()
    {
        var weekCategorySubCategories = await _transumWkCatSubSvc.FetchAllUniqueKeysAsync();

        Assert.NotNull(weekCategorySubCategories);
        Assert.NotEmpty(weekCategorySubCategories);
    }

    [Fact]
    public async Task GetByWeekCategorySubCategory_ReturnsWeekCategorySubCategory()
    {
        var dto = await _transumWkCatSubSvc.FetchByKeyAsync(new { Week = 1, Category = "car", SubCategory = "gas" });

        Assert.NotNull(dto);
        Assert.Equal(1, dto.Week);
        Assert.Equal("car", dto.Category);
        Assert.Equal("gas", dto.SubCategory);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumWkCatSubSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandom()
    {
        var dto = await _transumWkCatSubSvc.FetchRandomAsync();

        Assert.NotNull(dto);
        Assert.True(dto.Week is >= 1 and <= 53);
        Assert.NotNull(dto.Category);
        Assert.NotEmpty(dto.Category);
        Assert.NotNull(dto.SubCategory);
        Assert.NotEmpty(dto.SubCategory);
    }
}