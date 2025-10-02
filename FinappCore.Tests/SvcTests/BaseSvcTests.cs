using Microsoft.Extensions.DependencyInjection;
using Models.Tables;
using Repos.Shared;
using Services.Shared;

namespace FinappCore.Tests.SvcTests;

public class BaseSvcTests
{
    private readonly CommonSvc _svc;

    public BaseSvcTests()
    {
        // Use the real service provider to get the repo
        var provider = TestServiceInitializer.GetServiceProvider();

        // Resolve the real repo and service
        if (provider == null) return;
        var repo = provider.GetRequiredService<CommonRepo>();
        _svc = new CommonSvc(repo);
    }

    [Fact]
    public async Task FetchTotalCount_ReturnsNonNegativeValue()
    {
        // Act
        var total = await _svc.FetchTotalCount<CommonDto>();

        // Assert
        Assert.True(total >= 0, "Total count should be non-negative");
    }

    [Fact]
    public async Task FetchById_ReturnsEntityIfExists()
    {
        // You need an existing ID in your database
        string testId = "existing_id_here";

        var entity = await _svc.FetchById<CommonDto, string>(testId);

        Assert.NotNull(entity);
    }
}