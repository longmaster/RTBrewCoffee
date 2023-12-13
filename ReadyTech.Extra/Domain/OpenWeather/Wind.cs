using System.Text.Json.Serialization;

namespace Domain.OpenWeather
{
    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        public long Deg { get; set; }

        [JsonPropertyName("gust")]
        public double Gust { get; set; }
    }
}
