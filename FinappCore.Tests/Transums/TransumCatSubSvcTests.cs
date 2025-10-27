using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumCatSubSvcTests
{
    private readonly TransumCommonSvc<TransumCatSubDto, object> _transumCatSubSvc;

    public TransumCatSubSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _transumCatSubSvc = TransumServices.CatSub(dbContext);
    }

    [Fact]
    public async Task GetUniqueCategorySubCategoriesAsync_ReturnsNonEmptyList()
    {
        var categorySubCategories = await _transumCatSubSvc.FetchAllUniqueKeysAsync();

        Assert.NotNull(categorySubCategories);
        Assert.NotEmpty(categorySubCategories);
    }

    [Fact]
    public async Task GetByCategorySubCategory_ReturnsCategorySubCategory()
    {
        var dto = await _transumCatSubSvc.FetchByKeyAsync(new { Category = "life", SubCategory = "clothing" });

        Assert.NotNull(dto);
        Assert.Equal("life", dto.Category);
        Assert.Equal("clothing", dto.SubCategory);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumCatSubSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandom()
    {
        var dto = await _transumCatSubSvc.FetchRandomAsync();

        Assert.NotNull(dto);
        Assert.NotNull(dto.Category);
        Assert.NotEmpty(dto.Category);
        Assert.NotNull(dto.SubCategory);
        Assert.NotEmpty(dto.SubCategory);
    }
}