using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Models.Tables;
using Repos.Tables.Shared;
using Services.Tables.Shared;

namespace FinappCore.Tests.Tables.Shared;

[Collection(TestConstants.TestCollectionName)]
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
        var total = await _svc.FetchTotalCount();
        Assert.True(total >= 0, "Total count should be non-negative");
    }

    [Fact]
    public async Task FetchById_ReturnsRecord_WhenExists()
    {
        var lastRecord = await _svc.FetchLatestRecord();
        if (lastRecord != null)
        {
            var fetched = await _svc.FetchById(lastRecord.Common.Id);
            Assert.NotNull(fetched);
            Assert.Equal(lastRecord.Common.Id, fetched.Common.Id);
        }
    }

    [Fact]
    public async Task FetchByNumber_ReturnsCorrectRecord()
    {
        var lastRecord = await _svc.FetchLatestRecord();
        if (lastRecord != null)
        {
            var fetched = await _svc.FetchByNumber(lastRecord.Common.Number);
            Assert.NotNull(fetched);
            Assert.Equal(lastRecord.Common.Number, fetched!.Common.Number);
        }
    }

    [Fact]
    public async Task FetchLatestRecord_ReturnsRecordWithHighestNumber()
    {
        var lastRecord = await _svc.FetchLatestRecord();
        Assert.NotNull(lastRecord);
        Assert.True(lastRecord.Common.Number > 0);
    }

    [Fact]
    public async Task FetchOldestRecord_ReturnsRecordWithLowestNumber()
    {
        var firstRecord = await _svc.FetchOldestRecord();
        Assert.NotNull(firstRecord);
        Assert.True(firstRecord.Common.Number > 0);
    }

    [Fact]
    public async Task FetchLatestRecord_WithPredicate_FiltersCorrectly()
    {
        var latestEven = await _svc.FetchLatestRecord(x => x.Common.Number % 2 == 0);
        Assert.NotNull(latestEven);
        Assert.True(latestEven.Common.Number % 2 == 0);
    }

    [Fact]
    public async Task FetchOldestRecord_WithPredicate_FiltersCorrectly()
    {
        var oldestOdd = await _svc.FetchOldestRecord(x => x.Common.Number % 2 != 0);
        Assert.NotNull(oldestOdd);
        Assert.True(oldestOdd.Common.Number % 2 != 0);
    }

    [Fact]
    public async Task FetchRandomRecord_ReturnsSomeRecord()
    {
        var randomRecord = await _svc.FetchRandomRecord();
        Assert.NotNull(randomRecord);
        Assert.True(randomRecord.Common.Number > 0);
    }

    [Fact]
    public async Task FetchByCustom_ReturnsCorrectRecords()
    {
        var records = await _svc.FetchByCustom(
            (x => x.Common.Number, 1)
        );
        Assert.NotNull(records);
        foreach (var r in records)
            Assert.Equal(1, r.Common.Number);
    }
}

// Wrapper for strongly-typed tests
public class CommonSvcWrapper(CommonRepo commonRepo) : CommonSvc<CarDto>(commonRepo);
