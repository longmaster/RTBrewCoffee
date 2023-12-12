using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.WeatherData;
public interface IWeatherClient<T>
{
    Task<T> GetWeatherDataAsync();
}
