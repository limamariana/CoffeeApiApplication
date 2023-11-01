using System.Text.Json.Serialization;

namespace CoffeeApiApplication.Api.Response
{
    public class CoffeeResponse
    {
        [JsonPropertyName("Coffees")]
        public List<Coffee> Coffees { get; set; }
    }
}
