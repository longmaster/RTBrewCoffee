using Newtonsoft.Json;

namespace Domain.OpenWeather
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}
