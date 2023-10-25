using System.Text.Json.Serialization;

namespace CoffeeApiApplication.Api
{
	public class Coffee
	{
		public string Name { get; }

		public string Code { get; }

		public Coffee(string name, string code)
		{
			Name = name;
			Code = code;
		}
	}

	public class CoffeeResponse
	{
		[JsonPropertyName("Coffees")]
		public List<Coffee> Coffees { get; set; }
	}
}