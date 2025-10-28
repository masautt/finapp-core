using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumYrMoCatSubSvcTests
{
    private readonly TransumCommonSvc<TransumYrMoCatSubDto, object> _transumYrMoCatSubSvc;

    public TransumYrMoCatSubSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException(TestConstants.ServiceProviderInitError);

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _transumYrMoCatSubSvc = TransumServices.YrMoCatSub(dbContext);
    }

    [Fact]
    public async Task GetUniqueYearMonthCategorySubCategoriesAsync_ReturnsNonEmptyList()
    {
        var yearMonthCategorySubCategories = await _transumYrMoCatSubSvc.FetchAllUniqueKeysAsync();

        Assert.NotNull(yearMonthCategorySubCategories);
        Assert.NotEmpty(yearMonthCategorySubCategories);
    }

    [Fact]
    public async Task GetByYearMonthCategorySubCategory_ReturnsYearMonthCategorySubCategory()
    {
        var dto = await _transumYrMoCatSubSvc.FetchByKeyAsync(new { Year = 2024, Month = "jan", Category = "car", SubCategory = "gas" });

        Assert.NotNull(dto);
        Assert.Equal(2024, dto.Year);
        Assert.Equal("jan", dto.Month);
        Assert.Equal("car", dto.Category);
        Assert.Equal("gas", dto.SubCategory);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumYrMoCatSubSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandom()
    {
        var dto = await _transumYrMoCatSubSvc.FetchRandomAsync();

        Assert.NotNull(dto);
        Assert.True(dto.Year is >= 2000 and <= 2100);
        Assert.NotNull(dto.Month);
        Assert.NotEmpty(dto.Month);
        Assert.NotNull(dto.Category);
        Assert.NotEmpty(dto.Category);
        Assert.NotNull(dto.SubCategory);
        Assert.NotEmpty(dto.SubCategory);
    }
}