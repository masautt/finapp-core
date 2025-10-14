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


    [Fact]
    public async Task FetchUtilities_ReturnsOnlyUtilityFields()
    {
        // Act
        var utilities = await _housingSvc.FetchUtilities();

        // Assert
        Assert.NotNull(utilities);
        Assert.All(utilities, u =>
        {
            Assert.NotNull(u.UtilitiesDate);
            Assert.True(u.Electricity >= 0);
            Assert.True(u.Water >= 0);
            Assert.True(u.Gas >= 0);
            Assert.True(u.Wifi >= 0);
            Assert.True(u.CityServices >= 0);
        });
    }
}