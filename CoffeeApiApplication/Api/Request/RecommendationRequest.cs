using static CoffeeApiApplication.Api.Service.RecommedationService;

namespace CoffeeApiApplication.Api.Request
{
    public class RecommendationRequest
    {
        public List<RecommendationItem> Recommendations { get; set; }
    }
}
