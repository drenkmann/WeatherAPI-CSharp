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

		Assert.InRange(weather.TemperatureCelsius, -100, 100);
		Assert.NotEmpty(weather.ConditionText);
		Assert.InRange(weather.WindKph, 0, 200);
	}
}