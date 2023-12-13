using Domain.OpenWeather;

namespace Application.Interfaces;

public interface IWeatherDataEngine
{
    Task<OpenWeather> GetWeatherAsync(bool useCache = true);
}
