using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumYrWkSvcTests
{
    private readonly TransumCommonSvc<TransumYrWkDto, object> _transumYrWkSvc;

    public TransumYrWkSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        var dbContext = provider.GetRequiredService<AppDbContext>();
        _transumYrWkSvc = TransumServices.YrWk(dbContext);
    }

    [Fact]
    public async Task GetUniqueYearWeeksAsync_ReturnsNonEmptyList()
    {
        var yearWeeks = await _transumYrWkSvc.FetchAllUniqueKeysAsync();

        Assert.NotNull(yearWeeks);
        Assert.NotEmpty(yearWeeks);
        // Keys are anonymous objects with Year and Week properties
    }

    [Fact]
    public async Task GetByYearWeek_ReturnsYearWeek()
    {
        var dto = await _transumYrWkSvc.FetchByKeyAsync(new { Year = 2024, Week = 1 });

        Assert.NotNull(dto);
        Assert.Equal(2024, dto.Year);
        Assert.Equal(1, dto.Week);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumYrWkSvc.FetchCountAsync();
        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandom()
    {
        var dto = await _transumYrWkSvc.FetchRandomAsync();

        Assert.NotNull(dto);
        Assert.True(dto.Year is >= 2000 and <= 2100);
        Assert.True(dto.Week is >= 1 and <= 53);
    }
}