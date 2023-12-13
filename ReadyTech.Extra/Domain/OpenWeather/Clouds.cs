using System.Text.Json.Serialization;


namespace Domain.OpenWeather
{
    public class Clouds
    {
        [JsonPropertyName("all")]
        public long All { get; set; }
    }
}
