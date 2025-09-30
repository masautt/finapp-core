using Services.Interfaces;
using Xunit.Abstractions;

namespace FinappCore.Tests.SvcTests;

public class CarSvcTests
{
    private readonly ITestOutputHelper _output;
    private readonly ICarSvc _carSvc;

    public CarSvcTests(ITestOutputHelper output)
    {
        _output = output;

        TestServiceInitializer.ConfigureFactory();

        _carSvc = FinappSvcFactory.CreateCarSvc();
    }

    [Fact]
    public async Task CanGetCarCount()
    {
        var count = await _carSvc.GetTotalCount();
        Assert.True(count >= 0);
        _output.WriteLine($"Total car count: {count}");
    }

    [Fact]
    public async Task CanGetCarsByDateRange()
    {
        var start = DateTime.UtcNow.AddYears(-5);
        var end = DateTime.UtcNow;

        var response = await _carSvc.GetByDateRange(c => c.DateRange.StartDate, start, end);

        Assert.NotNull(response);
        _output.WriteLine($"Cars in date range ({start:yyyy-MM-dd} to {end:yyyy-MM-dd}): {response.Items.Count}");
        _output.WriteLine($"Page {response.Page.PageNumber} of {response.Page.TotalPages}, Page size: {response.Page.PageSize}");
    }

    [Fact]
    public async Task CanGetCarsByNumberRange()
    {
        const decimal min = 1;
        const decimal max = 100;

        var response = await _carSvc.GetByNumRange(c => c.Common.Number, min, max);

        Assert.NotNull(response);
        _output.WriteLine($"Cars with number between {min} and {max}: {response.Items.Count}");
        _output.WriteLine($"Page {response.Page.PageNumber} of {response.Page.TotalPages}, Page size: {response.Page.PageSize}");
    }
}