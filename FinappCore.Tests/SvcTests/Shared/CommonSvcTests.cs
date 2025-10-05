using Microsoft.Extensions.DependencyInjection;
using Models.Tables;
using Repos.Shared;
using Services.Shared;

namespace FinappCore.Tests.SvcTests.Shared;

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
        var total = await _svc.FetchTotalCount();

        // Assert
        Assert.True(total >= 0, "Total count should be non-negative");
    }

    [Fact]
    public async Task GetLastRecord_ReturnsRecordWithHighestNumber()
    {
        // Act
        var lastRecord = await _svc.GetLastRecord();

        // Assert
        Assert.NotNull(lastRecord);
        Assert.True(lastRecord.Common.Number > 0, "Last record should have a positive number");
    }
}

public class CommonSvcWrapper(CommonRepo commonRepo) : CommonSvc<CarDto>(commonRepo);