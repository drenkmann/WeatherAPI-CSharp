using Newtonsoft.Json;
using System.Net;

/// <summary>
/// Holds all classes needed to make API requests
/// </summary>
namespace WeatherAPI_CSharp;

/// <summary>
/// Client to make requests to weather api
/// </summary>
public class APIClient
{
	private readonly string _apiKey;
	private readonly bool _useHttps;

	/// <summary>
	/// Create APIClient with optional <paramref name="useHttps"/> parameter
	/// </summary>
	/// <param name="apiKey">Your API key</param>
	/// <param name="useHttps"><c>true</c>: Use https, <c>false</c>: Use http</param>
	public APIClient(string apiKey, bool useHttps = false)
	{
		_apiKey = apiKey;
		_useHttps = useHttps;
	}

	/// <summary>
	/// Get Current weather at <paramref name="query" /> location
	/// </summary>
	/// <param name="query">Weather location</param>
	/// <returns><see cref="Forecast"/> object with data from location</returns>
	/// <remarks>Returns default on http error. In this case, Forecast.Valid will be false.</remarks>
	public async Task<Forecast> GetWeatherCurrentAsync(string query)
	{
		var uri = new Uri($"{(_useHttps ? "https" : "http")}://api.weatherapi.com/v1/current.json?key={_apiKey}&q={query}");

		using var client = new HttpClient();

		try
		{
			var jsonResponse = await client.GetStringAsync(uri);
			dynamic jsonData = JsonConvert.DeserializeObject(jsonResponse)!;
			if (jsonData is null)
				throw new NullReferenceException();

			return new Forecast(jsonData.current);
		}
		catch(HttpRequestException e)
		{
			System.Diagnostics.Debug.WriteLine(e.StatusCode switch
			{
				HttpStatusCode.BadRequest => "Error 400 - Bad Request. Possible query error?",
				HttpStatusCode.Unauthorized => "Error 401 - Unauthorized. Possible API key error?",
				HttpStatusCode.Forbidden => "Error 403 - Forbidden. Possible API key error?",
				HttpStatusCode.NotFound => "Error 404 - Not Found.",
				_ => $"Error {e.StatusCode}"
			});
			return default;
		}
	}

	/// <summary>
	/// Get weather forecast for the next <paramref name="days" /> amount of days at <paramref name="query" /> location
	/// </summary>
	/// <param name="query">Weather location</param>
	/// <param name="days">Amount of days to get the forecast for</param>
	/// <returns>Array of <see cref="ForecastDaily"/> classes</returns>
	/// <remarks>Returns default on http error. In this case, ForecastDaily[0].Valid will be false.</remarks>
	public async Task<ForecastDaily[]> GetWeatherForecastDailyAsync(string query, int days = 7)
	{
		var uri = new Uri($"{(_useHttps ? "https" : "http")}://api.weatherapi.com/v1/forecast.json?key={_apiKey}&q={query}&days={days}");

		using var client = new HttpClient();

		try
		{
			var jsonResponse = await client.GetStringAsync(uri);
			dynamic jsonData = JsonConvert.DeserializeObject(jsonResponse)!;

			if (jsonData is null)
				throw new NullReferenceException();

			var forecasts = new ForecastDaily[days];
			var index = 0;

			foreach (var dailyData in jsonData.forecast.forecastday)
			{
				forecasts[index] = new ForecastDaily(dailyData);
				index++;
			}

			return forecasts;
		}
		catch(HttpRequestException e)
		{
			System.Diagnostics.Debug.WriteLine(e.StatusCode switch
			{
				HttpStatusCode.BadRequest => "Error 400 - Bad Request. Possible query error?",
				HttpStatusCode.Unauthorized => "Error 401 - Unauthorized. Possible API key error?",
				HttpStatusCode.Forbidden => "Error 403 - Forbidden. Possible API key error?",
				HttpStatusCode.NotFound => "Error 404 - Not Found.",
				_ => $"Error {e.StatusCode}"
			});
			return new ForecastDaily[]{default};
		}
	}

	/// <summary>
	/// Get weather forecast for the next <paramref name="hours" /> amount of hours at <paramref name="query" /> location
	/// </summary>
	/// <param name="query">Weather location</param>
	/// <param name="hours">Amount of hours to get the forecast for</param>
	/// <returns>Array of <see cref="ForecastHourly"/> classes</returns>
	/// <remarks>Returns default on http error. In this case, ForecastHourly[0].Valid will be false.</remarks>
	public async Task<ForecastHourly[]> GetWeatherForecastHourlyAsync(string query, int hours = 24)
	{
		var uri = new Uri($"{(_useHttps ? "https" : "http")}://api.weatherapi.com/v1/forecast.json?key={_apiKey}&q={query}&days={Math.Ceiling(hours / 24d)}");

		using var client = new HttpClient();

		try
		{
			var jsonResponse = await client.GetStringAsync(uri);
			dynamic jsonData = JsonConvert.DeserializeObject(jsonResponse)!;

			if (jsonData is null)
				throw new NullReferenceException();

			var forecasts = new ForecastHourly[hours];
			var index = 0;

			foreach (var dailyData in jsonData.forecast.forecastday)
			{
				foreach (var hourlyData in dailyData.hour)
				{
					forecasts[index] = new ForecastHourly(hourlyData);
					index++;
				}
			}

			return forecasts;
		}
		catch(HttpRequestException e)
		{
			System.Diagnostics.Debug.WriteLine(e.StatusCode switch
			{
				HttpStatusCode.BadRequest => "Error 400 - Bad Request. Possible query error?",
				HttpStatusCode.Unauthorized => "Error 401 - Unauthorized. Possible API key error?",
				HttpStatusCode.Forbidden => "Error 403 - Forbidden. Possible API key error?",
				HttpStatusCode.NotFound => "Error 404 - Not Found.",
				_ => $"Error {e.StatusCode}"
			});
			return new ForecastHourly[]{default};
		}
	}
}
