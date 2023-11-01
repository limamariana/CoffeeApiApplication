using CoffeeApiApplication.Api.Request;
using CoffeeApiApplication.Api.Response;
using static CoffeeApiApplication.Api.Service.RecommedationService;

namespace CoffeeApiApplication.Api.Interface
{
    public interface IRecommedationService
    {
        public RecommendationResponse CalculateNextCoffee(RecommendationRequest request);

        public double CalculateCaffeineWithHalfLife(double initialCaffeine, int totalTime, int halfLife);

        public int CalculateCaffeineConsumption(RecommendationRequest request);

        public int CalculateTotalTime(RecommendationRequest request);

    }
}
