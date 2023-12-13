using Application.Interfaces;
using Common.ConfigOptions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Infrastructure.Caching;

public class CachingManager : ICacheManager
{
    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<CachingManager> _logger;
    private readonly IOptions<CacheConfig> _cacheConfig;

    public CachingManager(
        IDistributedCache distributedCache,
        ILogger<CachingManager> logger,
        IOptions<CacheConfig> cacheConfig)
    {
        _distributedCache = distributedCache;
        _logger = logger;
        _cacheConfig = cacheConfig;

    }
    public async Task<T?> GetRecordAsync<T>(string key)
    {
        try
        {
          string result = await _distributedCache.GetStringAsync(key)??"";
           if (!string.IsNullOrEmpty(result)) 
            {
                T data = JsonSerializer.Deserialize<T>(result);

                if(data != null)
                    return data;
                else
                    return default;
            }

            return default(T);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            throw;
        }
    }

    public async Task SetRecordAsync<T>(
        string key,
        T data,
        TimeSpan? absoluteExpireTime = null,
        TimeSpan? unusedExpireTime = null)
    {

        try
        {

            DistributedCacheEntryOptions distributedCacheEntryOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromHours(_cacheConfig.Value.AbsoluteExpireTimeInHours),
                SlidingExpiration = unusedExpireTime ?? TimeSpan.FromSeconds(_cacheConfig.Value.SlidingExpirationTimeInHours)
            };

            string jsonData =  JsonSerializer.Serialize(data);

            await _distributedCache.SetStringAsync(key, jsonData, distributedCacheEntryOptions);
        }

        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }
}
