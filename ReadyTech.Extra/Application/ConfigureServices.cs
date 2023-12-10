using Application.Brew;
using Application.Interfaces;
using Common.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            if (services == null)
            { 
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSingleton<ICoffeeCounter, CoffeeCounter>();
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            });

            return services;
        }
    }
}
