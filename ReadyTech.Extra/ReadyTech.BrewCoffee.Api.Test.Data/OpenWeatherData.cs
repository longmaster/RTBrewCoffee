using Domain.OpenWeather;

namespace ReadyTech.BrewCoffee.Api.Tests.Data;
public static class OpenWeatherData
{
    public static OpenWeather CreateOpenWeatherData()
    {
        return new OpenWeather()
        {
            Coord = new Coord
            {
                Lon = -94.04,
                Lat = 33.44
            },
            Weather = new Weather[]
            {
                new Weather()
                {
                    Id = 800,
                    Main = "Clear",
                    Description = "clear sky",
                    Icon = "01n"
                },

            },
            Base = "stations",
            Main = new Main
            {
                Temp = 282.1,
                FeelsLike = 280.61,
                TempMin = 281.31,
                TempMax = 282.19,
                Pressure = 1027,
                Humidity = 58
            },
            Visibility = 10000,
            Wind = new Wind
            {
                Speed = 2.68,
                Deg = 129,
                Gust = 6.26
            },
            Clouds = new Clouds
            {
                All = 0
            },
            Dt = 1702625995,
            Sys = new Sys
            {
                Type = 2,
                Id = 62880,
                Country = "US",
                Sunrise = 1702645966,
                Sunset = 1702681789,
            },
            Timezone = -21600,
            Id = 4133367,
            Name = "Texarkana",
            Cod = 200

        };

    }

    public static string CreateOpenWeatherJsonString()
    {

        return "{\"coord\":{\"lon\":-94.04,\"lat\":33.44},\"weather\":[{\"id\":501,\"main\":\"Rain\",\"description\":\"moderaterain\",\"icon\":\"10n\"}]," +
            "\"base\":\"stations\",\"main\":{\"temp\":284.96,\"feels_like\":284.62,\"temp_min\":283.85,\"temp_max\":285.19,\"pressure\":1022,\"humidity\":93}," +
            "\"visibility\":10000,\"wind\":{\"speed\":1.79,\"deg\":299,\"gust\":2.24},\"rain\":{\"1h\":3.65},\"clouds\":{\"all\":100},\"dt\":1702692603,\"sys\":" +
            "{\"type\":2,\"id\":62880,\"country\":\"US\",\"sunrise\":1702645966,\"sunset\":1702681789},\"timezone\":-21600,\"id\":4133367,\"name\":\"Texarkana\"," +
            "\"cod\":200}";
    }

}