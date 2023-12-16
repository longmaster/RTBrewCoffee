
using System.Text.Json.Serialization;

namespace Application.Brew.Commands
{
    public class BrewCoffeeQueryResponse
    {
        [JsonPropertyName("statusMessage")]
        public string StatusMessage { get; set; }

        [JsonPropertyName("preparedDate")]
        public string PreparedDate { get; set; }
    }
}
