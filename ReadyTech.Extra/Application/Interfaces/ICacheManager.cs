using Microsoft.Extensions.Caching.Distributed;

namespace Application.Interfaces
{
    public interface ICacheManager
    {
        Task SetRecordAsync<T>(
            IDistributedCache distributedCache, 
            string key,
            T data, 
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null);

        Task<T> GetRecordAsync<T>(IDistributedCache distributedCache, string key);
    }
}
