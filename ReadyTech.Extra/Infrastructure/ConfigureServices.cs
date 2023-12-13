using Application.Interfaces;
using Common.Interfaces;
using Flurl.Http;
using Flurl.Http.Configuration;
using Infrastructure.Caching;
using Infrastructure.Policy;
using Infrastructure.WeatherData;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInsfrastructureServices(this IServiceCollection services, string redisConnectionString)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConnectionString ;
      
        });

        services.AddTransient<IDateTimeSnapshot, DateTimeSnapshot>();
        services.AddScoped<ICacheManager, CachingManager>();
        services.AddTransient(typeof(IWeatherClient<>), typeof(WeatherClient<>));
        services.AddTransient<IWeatherDataEngine, WeatherDataEngine>();

        // Polly - Retry & Timeout policies configuration
        FlurlHttp.Configure(settings => settings.HttpClientFactory = new CustomPollyHttpClientFactory());

        return services;
    }
}
