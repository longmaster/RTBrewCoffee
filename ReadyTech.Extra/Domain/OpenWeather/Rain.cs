using System.Text.Json.Serialization;

namespace Domain.OpenWeather
{
    public class Rain
    {
        [JsonPropertyName("1h")]
        public double OneHour {get;set;}
    }
}
