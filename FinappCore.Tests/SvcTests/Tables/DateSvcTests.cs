using Microsoft.Extensions.DependencyInjection;
using Models.Tables;
using Services.Shared;

namespace FinappCore.Tests.SvcTests.Tables;

public class DateSvcTests
{
    private readonly DateSvc _svc;

    public DateSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        _svc = provider.GetRequiredService<DateSvc>();
    }

    [Fact]
    public async Task FetchByDateRange_ReturnsResultsWithinRange()
    {
        // Arrange
        var start = new DateTime(2025, 1, 15, 0, 0, 0, DateTimeKind.Utc);
        var end = new DateTime(2025, 1, 20, 23, 59, 59, DateTimeKind.Utc);

        // Act
        var results = await _svc.FetchByDateRange<CarDto>(
            start,
            end,
            car => car.DateRange
        );

        // Assert
        Assert.NotNull(results);
        Assert.All(results, car =>
        {
            Assert.True(car.DateRange.StartDate <= end && car.DateRange.EndDate >= start,
                "CarDto should fall within the date range");
        });
    }
}
