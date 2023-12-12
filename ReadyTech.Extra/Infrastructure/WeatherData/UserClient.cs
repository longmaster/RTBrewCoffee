using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ConfigOptions;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.WeatherData;
public class WeatherClient<T> : IWeatherClient<T> where T : class
{
    private readonly IFlurlClient _flurlClient;
    private readonly ILogger<WeatherClient<T>> _logger;
    private readonly IOptions<EndPointConfig> _endPointConfig;


    public Task<T> GetWeatherDataAsync()
    {
        throw new NotImplementedException();
    }
}
