using System.Text;
using Common.ConfigOptions;
using Domain.OpenWeather;
using Infrastructure.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;
using ReadyTech.BrewCoffee.Api.Tests.Data;

namespace Infrastructure.Tests.Caching;
public class CachingManagerTests
{
    private readonly Mock<ILogger<CachingManager>> _mockLogger;
    private readonly Mock<IDistributedCache> _mockDistributedCache;
    private readonly Mock<IOptions<CacheConfig>> _mockOption;

    public CachingManagerTests() 
    {
        _mockLogger = new Mock<ILogger<CachingManager>>();
        _mockDistributedCache = new Mock<IDistributedCache>();
        _mockOption =  new Mock<IOptions<CacheConfig>>();

        _mockOption.Setup(x => x.Value).Returns(new CacheConfig() { AbsoluteExpireTimeInHours = 1, SlidingExpirationTimeInHours = 1 });
    }

    [Fact]
    public async Task GetRecordAsync_Execute_ReturnCacheData()
    {
        // Assign
        _mockDistributedCache.Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Encoding.ASCII.GetBytes(OpenWeatherData.CreateOpenWeatherJsonString()));

        // Act
        CachingManager cachingManager = new CachingManager(_mockDistributedCache.Object, _mockLogger.Object, _mockOption.Object);
        OpenWeather openWeather = await cachingManager.GetRecordAsync<OpenWeather>("cached-test");

        // Assert
        string resultJsonString = JsonSerializer.Serialize(openWeather);

        Assert.Equal(OpenWeatherData.CreateOpenWeatherJsonString(), resultJsonString);

    }

    [Fact]
    public async Task SetRecordAsync_Execute_VerifySetStringAsync()
    {
        // Assign
 

        // Act
        CachingManager cachingManager = new CachingManager(_mockDistributedCache.Object, _mockLogger.Object, _mockOption.Object);
        await cachingManager.SetRecordAsync("cached-test", OpenWeatherData.CreateOpenWeatherData());

        // Assert
        _mockDistributedCache.Verify(x => x.SetAsync(
            It.IsAny<string>(), 
            It.IsAny<byte[]>(), 
            It.IsAny<DistributedCacheEntryOptions>(), 
            It.IsAny<CancellationToken>()), 
            Times.Once);

    }

}
