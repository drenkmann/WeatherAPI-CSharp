using Xunit.Abstractions;

namespace WeatherAPI_CSharp.Tests;

public class APITests
{
	private readonly ITestOutputHelper output;
	private const string apiKey = "YOUR-API-KEY";

	public APITests(ITestOutputHelper output) => this.output = output;

	[Fact]
	public async Task TestGetWeatherCurrentAsync()
	{
		var client = new APIClient(apiKey, true);
		var weather = await client.GetWeatherCurrentAsync("Berlin");

		output.WriteLine(weather.ToString());

		Assert.True(weather.Valid);
		Assert.InRange(weather.TemperatureCelsius, -100, 100);
		Assert.NotEmpty(weather.ConditionText);
		Assert.InRange(weather.WindKph, 0, 200);
	}

	[Fact]
	public async Task TestGetWeatherCurrentAsyncFail()
	{
		var client = new APIClient(apiKey, true);
		var weather = await client.GetWeatherCurrentAsync("qwerpoiuqweropiuwqer9872345987");

		output.WriteLine(weather.ToString());

		Assert.False(weather.Valid);
	}

	[Fact]
	public async Task TestGetWeatherForecastDailyAsync()
	{
		var client = new APIClient(apiKey, true);
		var weather = await client.GetWeatherForecastDailyAsync("Berlin");

		foreach (var forecast in weather)
		{
			output.WriteLine(forecast.ToString());

			Assert.True(forecast.Valid);
			Assert.InRange(forecast.AvgTemperatureCelsius, -100, 100);
			Assert.NotEmpty(forecast.ConditionText);
			Assert.InRange(forecast.MaxWindKph, 0, 200);
		}
	}

	[Fact]
	public async Task TestGetWeatherForecastDailyAsyncFail()
	{
		var client = new APIClient(apiKey, true);
		var weather = await client.GetWeatherForecastDailyAsync("qwerpoiuqweropiuwqer9872345987");

		foreach (var forecast in weather)
		{
			output.WriteLine(forecast.ToString());

			Assert.False(forecast.Valid);
		}
	}
}