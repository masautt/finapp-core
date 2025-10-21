using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Services.Tables.Interfaces;

namespace FinappCore.Tests.Tables;

[Collection(TestConstants.TestCollectionName)]
public class HousingSvcTests
{
    private readonly IHousingSvc _housingSvc;

    public HousingSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");
        _housingSvc = provider.GetRequiredService<IHousingSvc>();
    }
}