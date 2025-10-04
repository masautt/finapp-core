using Microsoft.Extensions.DependencyInjection;
using Models.Tables;
using Services.Interfaces;

namespace FinappCore.Tests.SvcTests.Tables;

public class CarSvcTests
{
    private readonly ICarSvc _svc;

    public CarSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        _svc = provider.GetRequiredService<ICarSvc>();
    }

    [Fact]
    public async Task FetchTotalCount_ReturnsNonNegativeValue()
    {
        // Act
        var total = await _svc.FetchTotalCount<CarDto>();

        // Assert
        Assert.True(total >= 0, "Total count should be non-negative");
    }

    [Fact]
    public async Task FetchById_ReturnsEntityIfExists()
    {
        // Arrange
        const string testId = "e4kwzs";

        // Act
        var entity = await _svc.FetchById<CarDto, string>(testId);

        // Assert
        Assert.NotNull(entity);
    }
}