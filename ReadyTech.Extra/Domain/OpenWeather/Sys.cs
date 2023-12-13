using System.Text.Json.Serialization;

namespace Domain.OpenWeather
{
    public class Sys
    {
        [JsonPropertyName("type")]
        public long Type { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }
    }
}
