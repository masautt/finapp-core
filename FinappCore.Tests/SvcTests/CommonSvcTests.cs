using Microsoft.Extensions.DependencyInjection;
using Models.Tables;
using Repos.Shared;
using Xunit;

namespace FinappCore.Tests.SvcTests;

public class CommonSvcTests
{
    private readonly CommonSvcWrapper _svc;

    public CommonSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider not initialized.");

        var commonRepo = provider.GetRequiredService<CommonRepo>();
        _svc = new CommonSvcWrapper(commonRepo);
    }

    [Fact]
    public async Task FetchTotalCount_ReturnsNonNegative()
    {
        // Act
        var total = await _svc.FetchTotalCount<CarDto>();

        // Assert
        Assert.True(total >= 0, "Total count should be non-negative");
    }
}
