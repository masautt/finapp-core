using Database;
using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Transums;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection(TestConstants.TestCollectionName)]
public class TransumWkSvcTests
{
    private readonly TransumCommonSvc<TransumWkDto, int> _transumWkSvc;

    public TransumWkSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        // Resolve DbContext first
        var dbContext = provider.GetRequiredService<AppDbContext>();

        // Use the static factory
        _transumWkSvc = TransumServices.Wk(dbContext);
    }

    [Fact]
    public async Task GetUniqueWeeksAsync_ReturnsNonEmptyList()
    {
        var weeks = await _transumWkSvc.FetchAllUniqueKeysAsync();

        Assert.NotNull(weeks);
        Assert.NotEmpty(weeks);
        Assert.All(weeks, w => Assert.True(w is >= 1 and <= 53));
    }

    [Fact]
    public async Task GetByWeek_ReturnsWeek()
    {
        var dto = await _transumWkSvc.FetchByKeyAsync(1);

        Assert.NotNull(dto);
        Assert.Equal(1, dto.Week);
    }

    [Fact]
    public async Task FetchCountAsync_ReturnsPositiveNumber()
    {
        var count = await _transumWkSvc.FetchCountAsync();

        Assert.True(count > 0);
    }

    [Fact]
    public async Task FetchRandomAsync_ReturnsRandom()
    {
        var dto = await _transumWkSvc.FetchRandomAsync();

        Assert.NotNull(dto);
        Assert.True(dto.Week is >= 1 and <= 53);
    }
}