using static CoffeeApiApplication.Api.Service.RecommedationService;
using System.Text.Json.Serialization;

namespace CoffeeApiApplication.Api.Response
{
    public class RecommendationResponse
    {
        [JsonPropertyName("Recommedations")]
        public List<RecommendationItemWithWait> Recommendations { get; set; }
    }
}
