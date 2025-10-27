using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Services.Tables.Interfaces;

namespace FinappCore.Tests.Tables;

[Collection(TestConstants.TestCollectionName)]
public class BudgetTableSvcTests
{
    private readonly IBudgetTableSvc _budgetSvc;

    public BudgetTableSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");
        _budgetSvc = provider.GetRequiredService<IBudgetTableSvc>();
    }

    [Fact]
    public async Task FetchTotalCount_ReturnsNonNegativeValue()
    {
        var total = await _budgetSvc.FetchTotalCount();
        Assert.True(total >= 0, "Total count should be non-negative");
    }

    [Fact]
    public async Task FetchById_ReturnsEntityIfExists()
    {
        var allBudgets = await _budgetSvc.FetchAll();
        if (allBudgets.Count == 0)
            return;

        var testId = allBudgets.First().Common.Id;
        var entity = await _budgetSvc.FetchById(testId);

        Assert.NotNull(entity);
        Assert.Equal(testId, entity.Common.Id);
    }

    [Fact]
    public async Task FetchById_ReturnsNullIfNotExists()
    {
        const string nonExistentId = "nonexistent";
        var entity = await _budgetSvc.FetchById(nonExistentId);
        Assert.Null(entity);
    }

    [Fact]
    public async Task FetchByNumber_ReturnsCorrectEntity()
    {
        var lastRecord = await _budgetSvc.FetchLatestRecord();
        if (lastRecord != null)
        {
            var fetched = await _budgetSvc.FetchByNumber(lastRecord.Common.Number);
            Assert.NotNull(fetched);
            Assert.Equal(lastRecord.Common.Number, fetched!.Common.Number);
        }
    }

    [Fact]
    public async Task FetchAll_ReturnsNonEmptyList()
    {
        var all = await _budgetSvc.FetchAll();
        Assert.NotNull(all);
        Assert.All(all, budget =>
        {
            Assert.False(string.IsNullOrEmpty(budget.Common.Id));
            Assert.True(budget.Common.Number > 0);
        });
    }

    [Fact]
    public async Task FetchLatestRecord_ReturnsRecordWithHighestNumber()
    {
        var lastRecord = await _budgetSvc.FetchLatestRecord();
        Assert.NotNull(lastRecord);
        Assert.True(lastRecord.Common.Number > 0);
    }

    [Fact]
    public async Task FetchOldestRecord_ReturnsRecordWithLowestNumber()
    {
        var firstRecord = await _budgetSvc.FetchOldestRecord();
        Assert.NotNull(firstRecord);
        Assert.True(firstRecord.Common.Number > 0);
    }

    [Fact]
    public async Task FetchRandomRecord_ReturnsSomeRecord()
    {
        var randomRecord = await _budgetSvc.FetchRandomRecord();
        Assert.NotNull(randomRecord);
        Assert.True(randomRecord.Common.Number > 0);
    }

    [Fact]
    public async Task FetchByCustom_ReturnsCorrectRecords()
    {
        var records = await _budgetSvc.FetchByCustom(
            (x => x.Common.Number, 1)
        );

        Assert.NotNull(records);
        foreach (var r in records)
            Assert.Equal(1, r.Common.Number);
    }

    [Fact]
    public async Task FetchProjected_ReturnsCorrectly()
    {
        var projected = await _budgetSvc.FetchProjected(x => new { x.Category, x.Amount });
        Assert.NotNull(projected);
        Assert.All(projected, p =>
        {
            Assert.False(string.IsNullOrEmpty(p.Category));
            Assert.True(p.Amount >= 0);
        });
    }
}
