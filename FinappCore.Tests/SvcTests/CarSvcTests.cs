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
    public async Task CanGetAllCars()
    {
        var cars = await _carSvc.GetCarRows();
        Assert.NotNull(cars);
        _output.WriteLine($"Total cars fetched: {cars.Count}");
    }

    [Fact]
    public async Task CanGetCarCount()
    {
        var count = await _carSvc.GetCarCount();
        Assert.True(count >= 0); // count should never be negative
        _output.WriteLine($"Total car count: {count}");
    }

    [Fact]
    public async Task CanGetCarById()
    {
        var allCars = await _carSvc.GetCarRows();
        if (allCars.Count == 0)
        {
            _output.WriteLine("No cars in database to test GetCarById.");
            return;
        }

        var firstCar = allCars[0];
        var car = await _carSvc.GetCarRowById(firstCar.Common.Id);

        Assert.NotNull(car);
        Assert.Equal(firstCar.Common.Id, car!.Common.Id);
        _output.WriteLine($"Fetched car with ID: {car.Common.Id}");
    }

    [Fact]
    public async Task CanGetCarsByDateRange()
    {
        var start = DateTime.UtcNow.AddYears(-5);
        var end = DateTime.UtcNow;

        var cars = await _carSvc.GetCarRowsByDateRange(start, end);

        Assert.NotNull(cars);
        _output.WriteLine($"Cars in date range ({start:yyyy-MM-dd} to {end:yyyy-MM-dd}): {cars.Count}");
    }

    [Fact]
    public async Task CanGetCarsByNumberRange()
    {
        const int min = 1;
        const int max = 100;

        var cars = await _carSvc.GetCarRowsByNum(min, max);

        Assert.NotNull(cars);
        _output.WriteLine($"Cars with number between {min} and {max}: {cars.Count}");
    }
}
