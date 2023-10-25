using System.Text.Json.Serialization;
using static CoffeeApiApplication.Api.Service.RecommedationService;

namespace CoffeeApiApplication.Api.Service
{
	public class RecommedationService : IRecommedationService
	{
		private CoffeeInfoService coffeeInfoService;

		public RecommedationService(CoffeeInfoService coffeeInfoService)
		{
			this.coffeeInfoService = coffeeInfoService;
		}

		public RecommendationResponse CalculateNextCoffee(RecommendationRequest request)
		{
			int caffeineConsumed = CalculateCaffeineConsumption(request);
			int totalTime = CalculateTotalTime(request);

			double remainingCaffeine = 175 - CalculateCaffeineWithHalfLife(caffeineConsumed, totalTime, 300);

			List<CoffeeInfo> coffeeInfoList = this.coffeeInfoService.GetCoffeeInfo();
			List<CoffeeInfo> suitableCoffees = new List<CoffeeInfo>();

			foreach (CoffeeInfo coffeeInfo in coffeeInfoList)
			{
				if (coffeeInfo.ApproximateCaffeineLevel <= remainingCaffeine)
				{
					suitableCoffees.Add(coffeeInfo);
				}
			}

			if (suitableCoffees.Count > 0)
			{
				var recommendedCoffees = suitableCoffees.Select(coffee => coffee.CoffeeType).ToList();
				var waitTimes = suitableCoffees.Select(coffee => (int)(300 * Math.Log(remainingCaffeine / coffee.ApproximateCaffeineLevel))).ToList();

				var response = new RecommendationResponse
				{
					Recommendations = new List<RecommendationItemWithWait>()
				};

				for (int i = 0; i < recommendedCoffees.Count; i++)
				{
					response.Recommendations.Add(new RecommendationItemWithWait
					{
						name = recommendedCoffees[i],
						code = this.coffeeInfoService.GetCoffeeCodeByName(recommendedCoffees[i]),
						wait = waitTimes[i]
					});
				}

				return response;
			}

			return new RecommendationResponse
			{
				Recommendations = new List<RecommendationItemWithWait>()
			};
		}

		public double CalculateCaffeineWithHalfLife(double initialCaffeine, int totalTime, int halfLife)
		{
			double finalCaffeine = initialCaffeine * Math.Pow(0.5, (double)totalTime / halfLife);
			return finalCaffeine;
		}

		public int CalculateCaffeineConsumption(RecommendationRequest request)
		{
			List<CoffeeInfo> coffeeInfoList = this.coffeeInfoService.GetCoffeeInfo();
			int totalCaffeineConsumption = 0;

			foreach (RecommendationItem recommendation in request.Recommendations)
			{
				CoffeeInfo? coffeeInfo = coffeeInfoList.FirstOrDefault(info => info.CoffeeType == this.coffeeInfoService.GetCoffeeNameAndCode(recommendation.code));

				if (coffeeInfo != null)
				{
					totalCaffeineConsumption += coffeeInfo.ApproximateCaffeineLevel;
				}
			}

			return totalCaffeineConsumption;
		}

		public int CalculateTotalTime(RecommendationRequest request)
		{
			int totalTime = 0;

			foreach (RecommendationItem recommendation in request.Recommendations)
			{
				totalTime += recommendation.time;
			}

			return totalTime;
		}

		public class RecommendationRequest
		{
			public List<RecommendationItem> Recommendations { get; set; }
		}

		public class RecommendationItem
		{
			public string code { get; set; }
			public int time { get; set; }
		}

		public class RecommendationResponse
		{
			[JsonPropertyName("Recommedations")]
			public List<RecommendationItemWithWait> Recommendations { get; set; }
		}

		public class RecommendationItemWithWait
		{
			public string name { get; set; }
			public string code { get; set; }
			public int wait { get; set; }
		}

		public interface IRecommedationService
		{
			public RecommendationResponse CalculateNextCoffee(RecommendationRequest request);

			public double CalculateCaffeineWithHalfLife(double initialCaffeine, int totalTime, int halfLife);

			public int CalculateCaffeineConsumption(RecommendationRequest request);

			public int CalculateTotalTime(RecommendationRequest request);
		}
	}
}