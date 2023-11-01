namespace CoffeeApiApplication.Api.Service
{
	public class CoffeeInfoService
	{
		private Dictionary<string, string> coffeeCodeToName;
		private Dictionary<string, string> coffeeNameToCode;

		public CoffeeInfoService()
		{
			coffeeCodeToName = new Dictionary<string, string>
				{
					{"blk", "Black Coffee"},
					{"esp", "Espresso"},
					{"cap", "Cappuccino"},
					{"lat", "Latte"},
					{"wht", "Flat White"},
					{"cld", "Cold Brew"},
					{"dec", "Decaf Coffee"}
				};

			coffeeNameToCode = new Dictionary<string, string>();
			foreach (KeyValuePair<string, string> entry in coffeeCodeToName)
			{
				coffeeNameToCode[entry.Value] = entry.Key;
			}
		}

		public string GetCoffeeCodeByName(string name)
		{
			if (coffeeNameToCode.ContainsKey(name))
			{
				return coffeeNameToCode[name];
			}

			return "Coffee code not found";
		}

        public string GetCoffeeNameAndCode(string code)
        {
            if (coffeeCodeToName.ContainsKey(code))
            {
                return coffeeCodeToName[code];
            }

            return "Coffee name not found";
        }

        public List<CoffeeInfo> GetCoffeeInfo()
		{
			var coffeeInfo = new List<CoffeeInfo>
			{
				new CoffeeInfo
				{
					CoffeeType = "Black Coffee",
					ApproximateCaffeineLevel = 95
				},
				new CoffeeInfo
				{
					CoffeeType = "Espresso",
					ApproximateCaffeineLevel = 63
				},
				new CoffeeInfo
				{
					CoffeeType = "Cappuccino",
					ApproximateCaffeineLevel = 63
				},
				new CoffeeInfo
				{
					CoffeeType = "Latte",
					ApproximateCaffeineLevel = 63
				},
				new CoffeeInfo
				{
					CoffeeType = "Flat White",
					ApproximateCaffeineLevel = 63
				},
				new CoffeeInfo
				{
					CoffeeType = "Cold Brew",
					ApproximateCaffeineLevel = 120
				}
			};
			return coffeeInfo;
		}

		
	}
}