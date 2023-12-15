namespace Application.Interfaces;

public interface IWeatherClient<T>
{
    Task<T> GetWeatherDataAsync();
}
