using Microsoft.Extensions.DependencyInjection;
using Services.Transums;

namespace FinappCore.Tests.Transums;

[Collection("Database")]
public class TransumBusSvcTests
{
    private readonly TransumBusSvc _transumBusSvc;

    public TransumBusSvcTests()
    {
        var provider = TestServiceInitializer.GetServiceProvider();
        if (provider == null)
            throw new InvalidOperationException("Service provider could not be initialized.");

        _transumBusSvc = provider.GetRequiredService<TransumBusSvc>();
    }

    [Fact]
    public async Task GetUniqueBusinessesAsync_ReturnsNonEmptyList()
    {
        var businesses = await _transumBusSvc.GetUniqueBusinessesAsync();
        Assert.NotNull(businesses);
        Assert.All(businesses, b => Assert.False(string.IsNullOrEmpty(b)));
    }

    [Fact]
    public async Task GetByBusiness_ReturnsBusiness()
    {
        var dto = await _transumBusSvc.GetByBusinessAsync("Ralph's");
        Assert.NotNull(dto);
    }
}