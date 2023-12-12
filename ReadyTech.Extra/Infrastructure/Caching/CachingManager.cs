using Application.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infrastructure.Caching;

public class CachingManager : ICacheManager
{
    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<CachingManager> _logger;

    public CachingManager(
        IDistributedCache distributedCache,
        ILogger<CachingManager> logger)
    {
        _distributedCache = distributedCache;
        _logger = logger;

    }
    public async Task<T> GetRecordAsync<T>(string key)
    {
        try
        {
          string result = await _distributedCache.GetStringAsync(key)??"";
           if (!string.IsNullOrEmpty(result)) 
            {
                T data = JsonSerializer.Deserialize<T>(result);
                return data;
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
                AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(30),
                SlidingExpiration = unusedExpireTime ?? TimeSpan.FromSeconds(60)
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
