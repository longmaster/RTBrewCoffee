﻿using Newtonsoft.Json;

namespace Domain.OpenWeather
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public long Deg { get; set; }

        [JsonProperty("gust")]
        public double Gust { get; set; }
    }
}
