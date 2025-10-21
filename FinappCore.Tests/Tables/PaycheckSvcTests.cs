using FinappCore.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;
using Services.Tables.Interfaces;

namespace FinappCore.Tests.Tables;

[Collection(TestConstants.TestCollectionName)]
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
}