using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumYrWkCatSubSvcTests
{
    private readonly TransumCommonSvc<TransumYrWkCatSubDto, object> _transumYrWkCatSubSvc;

    public TransumYrWkCatSubSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _transumYrWkCatSubSvc = TransumServices.YrWkCatSub(dbContext);
    }

    [Fact]
    public async Task GetUniqueYearWeekCategorySubCategoriesAsync_ReturnsNonEmptyList()
    {
        var yearWeekCategorySubCategories = await _transumYrWkCatSubSvc.FetchAllUniqueKeysAsync();

        Assert.NotNull(yearWeekCategorySubCategories);
        Assert.NotEmpty(yearWeekCategorySubCategories);
    }

    [Fact]
    public async Task GetByYearWeekCategorySubCategory_ReturnsYearWeekCategorySubCategory()
    {
        var dto = await _transumYrWkCatSubSvc.FetchByKeyAsync(new { Year = 2024, Week = 1, Category = "car", SubCategory = "gas" });

        Assert.NotNull(dto);
        Assert.Equal(2024, dto.Year);
        Assert.Equal(1, dto.Week);
        Assert.Equal("car", dto.Category);
        Assert.Equal("gas", dto.SubCategory);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumYrWkCatSubSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandom()
    {
        var dto = await _transumYrWkCatSubSvc.FetchRandomAsync();

        Assert.NotNull(dto);
        Assert.True(dto.Year is >= 2000 and <= 2100);
        Assert.True(dto.Week is >= 1 and <= 53);
        Assert.NotNull(dto.Category);
        Assert.NotEmpty(dto.Category);
        Assert.NotNull(dto.SubCategory);
        Assert.NotEmpty(dto.SubCategory);
    }
}