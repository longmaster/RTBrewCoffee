
namespace Application.Interfaces;

public interface ICacheManager
{
    Task SetRecordAsync<T>(
        string key,
        T data, 
        TimeSpan? absoluteExpireTime = null,
        TimeSpan? unusedExpireTime = null);

    Task<T?> GetRecordAsync<T>(string key);
}
