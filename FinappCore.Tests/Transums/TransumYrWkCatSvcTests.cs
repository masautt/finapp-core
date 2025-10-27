using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumYrWkCatSvcTests
{
    private readonly TransumCommonSvc<TransumYrWkCatDto, object> _transumYrWkCatSvc;

    public TransumYrWkCatSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _transumYrWkCatSvc = TransumServices.YrWkCat(dbContext);
    }

    [Fact]
    public async Task GetUniqueYearWeekCategoriesAsync_ReturnsNonEmptyList()
    {
        var yearWeekCategories = await _transumYrWkCatSvc.FetchAllUniqueKeysAsync();

        Assert.NotNull(yearWeekCategories);
        Assert.NotEmpty(yearWeekCategories);
    }

    [Fact]
    public async Task GetByYearWeekCategory_ReturnsYearWeekCategory()
    {
        var dto = await _transumYrWkCatSvc.FetchByKeyAsync(new { Year = 2024, Week = 1, Category = "life" });

        Assert.NotNull(dto);
        Assert.Equal(2024, dto.Year);
        Assert.Equal(1, dto.Week);
        Assert.Equal("life", dto.Category);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumYrWkCatSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandom()
    {
        var dto = await _transumYrWkCatSvc.FetchRandomAsync();

        Assert.NotNull(dto);
        Assert.True(dto.Year is >= 2000 and <= 2100);
        Assert.True(dto.Week is >= 1 and <= 53);
        Assert.NotNull(dto.Category);
        Assert.NotEmpty(dto.Category);
    }
}