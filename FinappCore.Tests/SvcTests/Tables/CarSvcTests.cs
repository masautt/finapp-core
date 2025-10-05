using Microsoft.Extensions.DependencyInjection;
using Models.Tables;
using Services.Interfaces;

namespace FinappCore.Tests.SvcTests.Tables;

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
    }

    [Fact]
    public async Task GetLastRecord_ReturnsRecordWithHighestNumber()
    {
        var lastRecord = await _carSvc.GetLastRecord();
        Assert.NotNull(lastRecord);
        Assert.True(lastRecord.Common.Number > 0, "Last record should have a positive number");
    }

    // -------------------------------
    // New DateSvc tests
    // -------------------------------

    
}
