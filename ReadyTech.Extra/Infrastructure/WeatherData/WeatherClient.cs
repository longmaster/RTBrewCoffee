using Common.ConfigOptions;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Flurl;
using Application.Interfaces;

namespace Infrastructure.WeatherData;
public class WeatherClient<T> : IWeatherClient<T> where T : class
{
    private readonly IFlurlClient _flurlClient;
    private readonly ILogger<WeatherClient<T>> _logger;
    private readonly IOptions<EndPointConfig> _endPointConfig;
    private readonly object _weatherApiUrl;

    public WeatherClient(IFlurlClientFactory flurlClientFactory,
                        ILogger<WeatherClient<T>> logger,
                        IOptions<EndPointConfig> endPointConfig)
    {
        _logger = logger;
        _endPointConfig = endPointConfig;
        _weatherApiUrl = new
        {
            lat = _endPointConfig.Value.Latitude,
            lon = _endPointConfig.Value.Longitude,
            appid = _endPointConfig.Value.WeatherApiKey,
            units = _endPointConfig.Value.Unit
        };

        _flurlClient = flurlClientFactory.Get(_endPointConfig.Value.WeatherApiEndPoint.SetQueryParams(_weatherApiUrl));
    }

    public async Task<T> GetWeatherDataAsync()
    {
        try
        {
            IFlurlResponse flurlResponse = await _flurlClient.Request().AllowAnyHttpStatus().GetAsync();

            string responseBody = await flurlResponse.ResponseMessage.Content.ReadAsStringAsync();

            T weatherData = await flurlResponse.GetJsonAsync<T>();

            return weatherData;

        }
        catch (Exception ex) 
        {

            _logger.LogError($"{ex.Message}");

            throw;

        }
    }
}
