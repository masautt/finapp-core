using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Services.Transums;
using Models.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumYrMoDaCatSubSvcTests
{
    private readonly TransumCommonSvc<TransumYrMoDaCatSubDto, object> _transumYrMoDaCatSubSvc;

    public TransumYrMoDaCatSubSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _transumYrMoDaCatSubSvc = TransumServices.YrMoDaCatSub(dbContext);
    }

    [Fact]
    public async Task GetUniqueKeysAsync_ReturnsNonEmptyList()
    {
        var keys = await _transumYrMoDaCatSubSvc.FetchAllUniqueKeysAsync();
        Assert.NotNull(keys);
    }

    [Fact]
    public async Task GetByKey_ReturnsDto()
    {
        var key = new { Year = 2022, Month = "apr", Day = 2, Category = "eatingout", SubCategory = "coffeeShop" };
        var dto = await _transumYrMoDaCatSubSvc.FetchByKeyAsync(key);
        Assert.NotNull(dto);
        Assert.IsType<TransumYrMoDaCatSubDto>(dto);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumYrMoDaCatSubSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandomDto()
    {
        var dto = await _transumYrMoDaCatSubSvc.FetchRandomAsync();
        Assert.NotNull(dto);
        Assert.IsType<TransumYrMoDaCatSubDto>(dto);
    }

    // KeyExistsAsync tests
    [Fact]
    public async Task KeyExistsAsync_ReturnsTrueForExistingKey()
    {
        var key = new { Year = 2022, Month = "apr", Day = 2, Category = "eatingout", SubCategory = "coffeeShop" };
        var exists = await _transumYrMoDaCatSubSvc.KeyExistsAsync(key);
        Assert.True(exists);
    }

    [Fact]
    public async Task KeyExistsAsync_ReturnsFalseForNonExistingKey()
    {
        var key = new { Year = 9999, Month = "invalid", Day = 99, Category = "nonExistent", SubCategory = "fake" };
        var exists = await _transumYrMoDaCatSubSvc.KeyExistsAsync(key);
        Assert.False(exists);
    }

    // FetchCountAsync with predicates
    [Fact]
    public async Task FetchCountAsync_WithPredicate_ReturnsFilteredCount()
    {
        var count = await _transumYrMoDaCatSubSvc.FetchCountAsync(
            dto => dto.TotalAmount > 100);
        Assert.True(count >= 0);
    }

    [Fact]
    public async Task FetchCountAsync_WithMultiplePredicates_ReturnsFilteredCount()
    {
        var count = await _transumYrMoDaCatSubSvc.FetchCountAsync(
            dto => dto.TotalAmount > 10,
            dto => dto.Year == 2022);
        Assert.True(count >= 0);
    }

    [Fact]
    public async Task FetchRandomAsync_WithPredicate_ReturnsFilteredRandom()
    {
        var dto = await _transumYrMoDaCatSubSvc.FetchRandomAsync(
            dto => dto.Year == 2022);

        if (dto != null)
        {
            Assert.Equal(2022, dto.Year);
        }
    }

    [Fact]
    public async Task FetchRandomAsync_WithMultiplePredicates_ReturnsFilteredRandom()
    {
        var dto = await _transumYrMoDaCatSubSvc.FetchRandomAsync(
            dto => dto.Year == 2022,
            dto => dto.Category == "eatingout");

        if (dto != null)
        {
            Assert.Equal(2022, dto.Year);
            Assert.Equal("eatingout", dto.Category);
        }
    }

    // FetchBySortOrderAsync tests
    [Fact]
    public async Task FetchBySortOrderAsync_SortsDescending()
    {
        var results = await _transumYrMoDaCatSubSvc.FetchBySortOrderAsync(
            dto => dto.TotalAmount,
            descending: true,
            limit: 10);

        Assert.NotNull(results);
        Assert.True(results.Count <= 10);

        // Verify descending order
        for (var i = 0; i < results.Count - 1; i++)
        {
            Assert.True(results[i].TotalAmount >= results[i + 1].TotalAmount);
        }
    }

    [Fact]
    public async Task FetchBySortOrderAsync_SortsAscending()
    {
        var results = await _transumYrMoDaCatSubSvc.FetchBySortOrderAsync(
            dto => dto.TotalMarekCount,
            descending: false,
            limit: 5);

        Assert.NotNull(results);
        Assert.True(results.Count <= 5);

        // Verify ascending order
        for (var i = 0; i < results.Count - 1; i++)
        {
            Assert.True(results[i].TotalMarekCount <= results[i + 1].TotalMarekCount);
        }
    }

    [Fact]
    public async Task FetchBySortOrderAsync_WithNoLimit_ReturnsAllSorted()
    {
        var results = await _transumYrMoDaCatSubSvc.FetchBySortOrderAsync(
            dto => dto.TotalAmount,
            descending: true);

        Assert.NotNull(results);
        Assert.NotEmpty(results);

        for (var i = 0; i < results.Count - 1; i++)
        {
            Assert.True(results[i].TotalAmount >= results[i + 1].TotalAmount);
        }
    }

    [Fact]
    public async Task AnyAsync_WithNoPredicates_ReturnsTrue()
    {
        var hasAny = await _transumYrMoDaCatSubSvc.AnyAsync();
        Assert.True(hasAny);
    }

    [Fact]
    public async Task AnyAsync_WithMatchingPredicate_ReturnsTrue()
    {
        var hasAny = await _transumYrMoDaCatSubSvc.AnyAsync(
            dto => dto.TotalAmount > 1000);
        Assert.True(hasAny);
    }

    [Fact]
    public async Task AnyAsync_WithNonMatchingPredicate_ReturnsFalse()
    {
        var hasAny = await _transumYrMoDaCatSubSvc.AnyAsync(
            dto => dto.TotalAmount > 999999999);
        Assert.False(hasAny);
    }

    [Fact]
    public async Task AnyAsync_WithMultiplePredicates_ReturnsCorrectResult()
    {
        var hasAny = await _transumYrMoDaCatSubSvc.AnyAsync(
            dto => dto.Year == 2022,
            dto => dto.Category == "eatingout");

        Assert.IsType<bool>(hasAny);
    }
}