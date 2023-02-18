[![License](https://img.shields.io/badge/license-MIT-limegreen?style=for-the-badge)](./LICENSE.md)
[![Documentation](https://img.shields.io/badge/DOCUMENTATION-blue?style=for-the-badge)](https://skratymir.github.io/WeatherAPI-CSharp/)
[![Nuget](https://img.shields.io/nuget/v/WeatherAPI-CSharp?label=Version&style=for-the-badge)](https://www.nuget.org/packages/WeatherAPI-CSharp)

# WeatherAPI CSharp
This is a small wrapper library to be used with the weatherapi.com API. It is a much simpler alternative to the [official]("https://github.com/weatherapicom/csharp") library, with the goal to make building any kind of weather app much simpler. There are no complicated classes are functions to worry about, you just create your client, call the function, and get perfectly parsed, easily acessable data returned, no need for verbose code.

## Getting started (Extract from the documentation)
To get started, you can take a look at the minimal setup down below.

```csharp
using WeatherAPI_CSharp;

var client = new APIClient("YOUR-API-KEY");

var weather = await client.GetWeatherCurrentAsync("Berlin");
Console.WriteLine($"The temperature in Berlin is {weather.TemperatureCelsius}C at a wind speed of {weather.WindKph}km/h");
```

## API Implementation
The currently implemented [endpoints](https://www.weatherapi.com/docs/) are:
- [Current](https://skratymir.github.io/WeatherAPI-CSharp/api/WeatherAPI_CSharp.Forecast.html) (current.json)
- [Forecast daily](https://skratymir.github.io/WeatherAPI-CSharp/api/WeatherAPI_CSharp.ForecastDaily.html) (forecast.json)

## Contribution
For contribution guidelines, refer to the [documentation](https://skratymir.github.io/WeatherAPI-CSharp/).
Coding guidelines can be found [here](https://skratymir.github.io/WeatherAPI-CSharp/guidelines/codestyle.html), and contribution guidelines can be found [here](https://skratymir.github.io/WeatherAPI-CSharp/guidelines/contribution.html).

## License
This software is licensed under the [MIT License](LICENSE.md).
