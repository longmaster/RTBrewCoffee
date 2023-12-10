using Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInsfrastructureServices(this IServiceCollection services, string redisConnectionString)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConnectionString ;
     

                options.ConfigurationOptions = new ConfigurationOptions()
                {
                    ConnectRetry = 4,
                    ReconnectRetryPolicy = new LinearRetry(2000)
                };
            });

            services.AddScoped<IDateTimeSnapshot, DateTimeSnapshot>();

            return services;
        }
    }
}
