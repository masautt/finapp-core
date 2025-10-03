using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace FinappCore.Tests.SvcTests.Tables;

public class PaycheckSvcTests
{
    private readonly IPaycheckSvc _svc;

    public PaycheckSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        _svc = provider.GetRequiredService<IPaycheckSvc>();
    }

    [Fact]
    public async Task GetLatestTimeOff_ReturnsNonNullObject_WhenPaychecksExist()
    {
        // Act
        var result = await _svc.GetLatestTimeOff();

        // Assert
        Assert.NotNull(result);
    }
}