using Application.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infrastructure.Caching;

public class CachingManager : ICacheManager
{
    private readonly IDistributedCache _distributeCache;
    private readonly ILogger<CachingManager> _logger;

    public CachingManager(
        IDistributedCache distributedCache,
        ILogger<CachingManager> logger)
    {
        _distributeCache = distributedCache;
        _logger = logger;

    }
    public async Task<IEnumerable<T>> GetCollectionAsync<T>(int chunkSize) where T : notnull
    {
        try
        {

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return Enumerable.Empty<T>();
        }
        return Enumerable.Empty<T>();
    }

    public async Task SetRecordAsync<T>(
        IDistributedCache distributedCache,
        string key,
        T data,
        TimeSpan? absoluteExpireTime = null,
        TimeSpan? unusedExpireTime = null)
    {

        try
        {

            DistributedCacheEntryOptions distributedCacheEntryOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(30),
                SlidingExpiration = unusedExpireTime ?? TimeSpan.FromSeconds(60)
            };

            string jsonData = JsonSerializer.Serialize(data);

            await distributedCache.SetStringAsync(key, jsonData, distributedCacheEntryOptions);

        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

        }
    }
}
