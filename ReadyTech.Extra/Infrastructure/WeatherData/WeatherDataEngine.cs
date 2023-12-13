using Application.Interfaces;
using Domain.OpenWeather;

namespace Infrastructure.WeatherData;
public class WeatherDataEngine : IWeatherDataEngine
{
    private readonly IWeatherClient<OpenWeather> _weatherClient;
    private readonly ICacheManager _cacheManager;

    private const string WeatherCachedKey = "TodayWeather";
    public WeatherDataEngine(
        IWeatherClient<OpenWeather> weatherClient, 
        ICacheManager cacheManager)
    {
        _weatherClient = weatherClient;
        _cacheManager = cacheManager;
    }
    public async Task<OpenWeather> GetWeatherAsync(bool useCache = true)
    {
        OpenWeather openWeather = await _cacheManager.GetRecordAsync<OpenWeather>(WeatherCachedKey);
        if (useCache && openWeather != null)
        {
            return openWeather;
        }
        else {
            openWeather = await _weatherClient.GetWeatherDataAsync();
            if (openWeather != null)
            {
                await _cacheManager.SetRecordAsync(WeatherCachedKey, openWeather);
                return openWeather;
            }
            return new OpenWeather();
        }
    }
}
