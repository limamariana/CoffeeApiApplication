using CoffeeApiApplication.Api;
using CoffeeApiApplication.Api.Interface;
using CoffeeApiApplication.Api.Request;
using CoffeeApiApplication.Api.Response;
using CoffeeApiApplication.Api.Service;



WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IRecommedationService, RecommedationService>();
builder.Services.AddSingleton<CoffeeInfoService>();
builder.Services.AddScoped<ICoffeeService, CoffeeService>();

WebApplication app = builder.Build();

app.MapGet("/v1/coffees", (ICoffeeService coffeeService) =>
{
	List<Coffee> coffees = coffeeService.GetCoffees();

	var response = new CoffeeResponse { Coffees = coffees };
	return Results.Ok(response);
});

app.MapPost("/v1/calculate", (RecommendationRequest request, IRecommedationService recommendationService) =>
{
	RecommendationResponse nextCoffeeResponse = recommendationService.CalculateNextCoffee(request);

	return Results.Ok(nextCoffeeResponse);
});

app.Run();