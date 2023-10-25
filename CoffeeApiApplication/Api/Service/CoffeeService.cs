namespace CoffeeApiApplication.Api.Service
{
	public class CoffeeService : ICoffeeService
	{
		private List<Coffee> GetCoffees()
		{
			return new List<Coffee>
		{
			new Coffee("Black Coffee", "blk"),
			new Coffee("Espresso", "esp"),
			new Coffee("Cappuccino", "cap"),
			new Coffee("Latte", "lat"),
			new Coffee("Flat White", "wht"),
			new Coffee("Cold Brew", "cld"),
			new Coffee("Decaf Coffee", "dec")
		};
		}

		List<Coffee> ICoffeeService.GetCoffees()
		{
			return GetCoffees();
		}
	}

	public interface ICoffeeService
	{
		List<Coffee> GetCoffees();
	}
}