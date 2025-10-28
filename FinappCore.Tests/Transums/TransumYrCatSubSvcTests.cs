using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumYrCatSubSvcTests
{
    private readonly TransumCommonSvc<TransumYrCatSubDto, object> _transumYrCatSubSvc;

    public TransumYrCatSubSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException(TestConstants.ServiceProviderInitError);

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _transumYrCatSubSvc = TransumServices.YrCatSub(dbContext);
    }

    [Fact]
    public async Task GetUniqueYearCategorySubCategoriesAsync_ReturnsNonEmptyList()
    {
        var yearCategorySubCategories = await _transumYrCatSubSvc.FetchAllUniqueKeysAsync();

        Assert.NotNull(yearCategorySubCategories);
        Assert.NotEmpty(yearCategorySubCategories);
    }

    [Fact]
    public async Task GetByYearCategorySubCategory_ReturnsYearCategorySubCategory()
    {
        var dto = await _transumYrCatSubSvc.FetchByKeyAsync(new { Year = 2024, Category = "life", SubCategory = "clothing" });

        Assert.NotNull(dto);
        Assert.Equal(2024, dto.Year);
        Assert.Equal("life", dto.Category);
        Assert.Equal("clothing", dto.SubCategory);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumYrCatSubSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandom()
    {
        var dto = await _transumYrCatSubSvc.FetchRandomAsync();

        Assert.NotNull(dto);
        Assert.True(dto.Year is >= 2000 and <= 2100);
        Assert.NotNull(dto.Category);
        Assert.NotEmpty(dto.Category);
        Assert.NotNull(dto.SubCategory);
        Assert.NotEmpty(dto.SubCategory);
    }
}