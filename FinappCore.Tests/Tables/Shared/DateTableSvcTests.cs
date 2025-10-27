using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Tables;
using Services.Tables.Shared;

namespace FinappCore.Tests.Tables.Shared;

[Collection(TestConstants.TestCollectionName)]
public class DateTableSvcTests
{
    private readonly DateTableSvc<CarTableDto> _carDateSvc;
    private readonly DateTableSvc<ContributionTableDto> _contributionDateSvc;

    public DateTableSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        _carDateSvc = provider.GetRequiredService<DateTableSvc<CarTableDto>>();
        _contributionDateSvc = provider.GetRequiredService<DateTableSvc<ContributionTableDto>>();
    }

    [Fact]
    public async Task FetchByDateRangeWithDateRangeFields()
    {
        // Arrange
        var start = new DateTime(2025, 1, 15, 0, 0, 0, DateTimeKind.Utc);
        var end = new DateTime(2025, 1, 20, 23, 59, 59, DateTimeKind.Utc);

        // Act
        var results = await _carDateSvc.FetchByDateRange(
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

    [Fact]
    public async Task FetchByDateRangeWithExactDateFields_ReturnsContributions()
    {
        // Arrange
        var start = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var end = new DateTime(2025, 1, 31, 23, 59, 59, DateTimeKind.Utc);

        // Act
        var results = await _contributionDateSvc.FetchByDateRangeWithExactDateFields(
            start,
            end,
            c => c.Date
        );

        // Assert
        Assert.NotNull(results);
        Assert.All(results, c =>
        {
            Assert.True(c.Date.Date >= start && c.Date.Date <= end,
                "ContributionDto.Date.Date should fall within the date range");
        });
    }
}