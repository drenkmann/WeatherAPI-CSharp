[![License](https://img.shields.io/badge/license-MIT-limegreen?style=for-the-badge)](./LICENSE.md)
[![Documentation](https://img.shields.io/badge/DOCUMENTATION-blue?style=for-the-badge)](https://underthefoxtree.github.io/WeatherAPI-CSharp/)
[![Nuget](https://img.shields.io/nuget/v/WeatherAPI-CSharp?label=Version&style=for-the-badge)](https://www.nuget.org/packages/WeatherAPI-CSharp)
[![Nuget](https://img.shields.io/nuget/dt/WeatherAPI-CSharp?style=for-the-badge)](https://www.nuget.org/stats/packages/WeatherAPI-CSharp?groupby=Version)
[![Development Status](https://img.shields.io/badge/DEVELOPMENT-ON_DEMAND-yellow?style=for-the-badge)](#development-status)
#### All badges are clickable for more information
&nbsp;

# WeatherAPI CSharp
This is a small wrapper library to be used with the weatherapi.com API. It is a much simpler alternative to the [official]("https://github.com/weatherapicom/csharp") library, with the goal to make building any kind of weather app easy. There are no complicated classes are functions to worry about, you just create your client, call the function, and get perfectly parsed, easily acessable data returned, no need for verbose code.

## Getting started (Extract from the documentation)
To get started, you can take a look at the minimal setup down below.

Install the package
```shell
dotnet add package WeatherAPI-CSharp
```
Setup a minimal project
```csharp
using WeatherAPI_CSharp;

var client = new APIClient("YOUR-API-KEY");

var weather = await client.GetWeatherCurrentAsync("Berlin");
Console.WriteLine($"The temperature in Berlin is {weather.TemperatureCelsius}C at a wind speed of {weather.WindKph}km/h");
```

## API Implementation
The currently implemented [endpoints](https://www.weatherapi.com/docs/) are:
- [Current](https://underthefoxtree.github.io/WeatherAPI-CSharp/api/WeatherAPI_CSharp.Forecast.html) (current.json)
- [Forecast daily](https://underthefoxtree.github.io/WeatherAPI-CSharp/api/WeatherAPI_CSharp.ForecastDaily.html) (forecast.json)
- [Forecast hourly](https://underthefoxtree.github.io/WeatherAPI-CSharp/api/WeatherAPI_CSharp.ForecastHourly.html) (forecast.json)
- [IP Lookup](https://underthefoxtree.github.io/WeatherAPI-CSharp/api/WeatherAPI_CSharp.LocationData.html) (ip.json)

## Contribution
For contribution guidelines, refer to the [documentation](https://underthefoxtree.github.io/WeatherAPI-CSharp/).
Coding guidelines can be found [here](https://underthefoxtree.github.io/WeatherAPI-CSharp/guidelines/codestyle.html), and contribution guidelines can be found [here](https://underthefoxtree.github.io/WeatherAPI-CSharp/guidelines/contribution.html).

## Development Status
Status | Description
---|---
Active | The project is actively being worked on and new features are being added
On Demand | Bugs and other Issues will be fixed, but no new features will be added
Paused | No development will take place at the moment, but this may change in the future
Ceased | The project will not be worked on AT ALL

The development status can change at any time in both ways (more/less work being done).

## License
This software is licensed under the [MIT License](LICENSE.md).
