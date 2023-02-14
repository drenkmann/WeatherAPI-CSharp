using WeatherAPI_CSharp;

var client = new APIClient("YOUR-API-KEY", true);

var weather = await client.GetWeatherCurrentAsync("Berlin");
Console.WriteLine($"Die Temperatur in Berlin betraegt {weather.TemperatureCelsius}C bei einer Windgeschwindingkeit von {weather.WindKph}km/h");
