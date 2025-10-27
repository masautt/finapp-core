using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Services.Tables.Interfaces;
using Models.Tables;

namespace FinappCore.Tests.Tables;

[Collection(TestConstants.TestCollectionName)]
public class PaycheckTableSvcTests
{
    private readonly IPaycheckTableSvc _paycheckSvc;

    public PaycheckTableSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException(TestConstants.ServiceProviderInitError);
        _paycheckSvc = provider.GetRequiredService<IPaycheckTableSvc>();
    }

    [Fact]
    public async Task FetchTotalCount_ReturnsNonNegativeValue()
    {
        var total = await _paycheckSvc.FetchTotalCount();
        Assert.True(total >= 0, "Total count should be non-negative");
    }

    [Fact]
    public async Task FetchById_ReturnsEntityIfExists()
    {
        const string testId = "dscb7p";
        var entity = await _paycheckSvc.FetchById(testId);
        Assert.NotNull(entity);
        Assert.Equal(testId, entity.Common.Id);
    }

    [Fact]
    public async Task FetchById_ReturnsNullIfNotExists()
    {
        const string nonExistentId = "nonexistent";
        var entity = await _paycheckSvc.FetchById(nonExistentId);
        Assert.Null(entity);
    }

    [Fact]
    public async Task FetchByNumber_ReturnsCorrectEntity()
    {
        var lastRecord = await _paycheckSvc.FetchLatestRecord();
        if (lastRecord != null)
        {
            var fetched = await _paycheckSvc.FetchByNumber(lastRecord.Common.Number);
            Assert.NotNull(fetched);
            Assert.Equal(lastRecord.Common.Number, fetched!.Common.Number);
        }
    }

    [Fact]
    public async Task FetchLatestRecord_ReturnsRecordWithHighestNumber()
    {
        var lastRecord = await _paycheckSvc.FetchLatestRecord();
        Assert.NotNull(lastRecord);
        Assert.True(lastRecord.Common.Number > 0, "Last record should have a positive number");
    }

    [Fact]
    public async Task FetchOldestRecord_ReturnsRecordWithLowestNumber()
    {
        var firstRecord = await _paycheckSvc.FetchOldestRecord();
        Assert.NotNull(firstRecord);
        Assert.True(firstRecord.Common.Number > 0, "First record should have a positive number");
    }

    [Fact]
    public async Task FetchLatestRecord_WithPredicate_FiltersCorrectly()
    {
        var latestEven = await _paycheckSvc.FetchLatestRecord(x => x.Common.Number % 2 == 0);
        Assert.NotNull(latestEven);
        Assert.True(latestEven.Common.Number % 2 == 0);
    }

    [Fact]
    public async Task FetchOldestRecord_WithPredicate_FiltersCorrectly()
    {
        var oldestOdd = await _paycheckSvc.FetchOldestRecord(x => x.Common.Number % 2 != 0);
        Assert.NotNull(oldestOdd);
        Assert.True(oldestOdd!.Common.Number % 2 != 0);
    }

    [Fact]
    public async Task FetchRandomRecord_ReturnsSomeRecord()
    {
        var randomRecord = await _paycheckSvc.FetchRandomRecord();
        Assert.NotNull(randomRecord);
        Assert.True(randomRecord.Common.Number > 0);
    }

    [Fact]
    public async Task FetchByCustom_ReturnsCorrectRecords()
    {
        var records = await _paycheckSvc.FetchByCustom(
            (x => x.Common.Number, 1)
        );

        Assert.NotNull(records);
        foreach (var r in records)
            Assert.Equal(1, r.Common.Number);
    }

    [Fact]
    public async Task FetchByDateRange_ReturnsRecordsInRange()
    {
        var startDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var endDate = new DateTime(2024, 12, 31, 23, 59, 59, DateTimeKind.Utc);

        var results = await _paycheckSvc.FetchByDateRange(
            startDate,
            endDate,
            p => p.DateRange
        );

        Assert.NotNull(results);
        Assert.All(results, paycheck =>
        {
            Assert.True(paycheck.DateRange.StartDate <= endDate && paycheck.DateRange.EndDate >= startDate);
        });
    }

    [Fact]
    public async Task FetchByDateRange_ReturnsEmptyListWhenNoMatches()
    {
        var startDate = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var endDate = new DateTime(1900, 12, 31, 23, 59, 59, DateTimeKind.Utc);

        var results = await _paycheckSvc.FetchByDateRange(
            startDate,
            endDate,
            p => p.DateRange
        );

        Assert.NotNull(results);
        Assert.Empty(results);
    }
}
