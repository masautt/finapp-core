using Microsoft.Extensions.DependencyInjection;
using Models.Tables;
using Services.Interfaces;

namespace FinappCore.Tests.SvcTests.Tables;

[Collection("Database")]
public class CarSvcTests
{
    private readonly ICarSvc _carSvc;

    public CarSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");
        _carSvc = provider.GetRequiredService<ICarSvc>();
    }

    [Fact]
    public async Task FetchTotalCount_ReturnsNonNegativeValue()
    {
        var total = await _carSvc.FetchTotalCount();
        Assert.True(total >= 0, "Total count should be non-negative");
    }

    [Fact]
    public async Task FetchById_ReturnsEntityIfExists()
    {
        const string testId = "e4kwzs";
        var entity = await _carSvc.FetchById(testId);
        Assert.NotNull(entity);
        Assert.Equal(testId, entity.Common.Id);
    }

    [Fact]
    public async Task FetchById_ReturnsNullIfNotExists()
    {
        const string nonExistentId = "nonexistent";
        var entity = await _carSvc.FetchById(nonExistentId);
        Assert.Null(entity);
    }

    [Fact]
    public async Task GetLastRecord_ReturnsRecordWithHighestNumber()
    {
        var lastRecord = await _carSvc.GetLastRecord();
        Assert.NotNull(lastRecord);
        Assert.True(lastRecord.Common.Number > 0, "Last record should have a positive number");
    }

    [Fact]
    public async Task FetchByCustom_ReturnsMatchingRecords()
    {
        var filters = new Dictionary<string, object>();

        var results = await _carSvc.FetchByCustom(filters);
        Assert.NotNull(results);
    }

    [Fact]
    public async Task FetchByDateRange_ReturnsRecordsInRange()
    {
        var startDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var endDate = new DateTime(2024, 12, 31, 23, 59, 59, DateTimeKind.Utc);

        var results = await _carSvc.FetchByDateRange(
            startDate,
            endDate,
            c => c.DateRange
        );

        Assert.NotNull(results);
        Assert.All(results, car =>
        {
            Assert.True(car.DateRange.StartDate <= endDate && car.DateRange.EndDate >= startDate);
        });
    }

    [Fact]
    public async Task FetchByDateRange_ReturnsEmptyListWhenNoMatches()
    {
        var startDate = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var endDate = new DateTime(1900, 12, 31, 23, 59, 59, DateTimeKind.Utc);

        var results = await _carSvc.FetchByDateRange(
            startDate,
            endDate,
            c => c.DateRange
        );

        Assert.NotNull(results);
        Assert.Empty(results);
    }

}