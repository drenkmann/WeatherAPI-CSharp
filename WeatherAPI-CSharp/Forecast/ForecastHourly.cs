using System.ComponentModel;

namespace WeatherAPI_CSharp;

/// <summary>
/// Data class that holds hourly data parsed from forecast api response
/// </summary>
public readonly struct ForecastHourly
{
	/// <value>Whether or not the API request was successfull</value>
	public bool Valid { get; }
	/// <value>Date and time of forecast</value>
	public DateTime Date { get; }
	/// <value>Date and time of forecast as unix time</value>
	public long DateEpoch { get; }
	/// <value>Temperature in celsius</value>
	public double TemperatureCelsius { get; }
	/// <value>Temperature in fahrenheit</value>
	public double TemperatureFahrenheit { get; }
	/// <value>Weather condition text</value>
	public string ConditionText { get; }
	/// <value>Weather condition icon</value>
	public string ConditionIconUrl { get; }
	/// <value>Weather condition code</value>
	public int ConditionCode { get; }
	/// <value>Maximum wind speed in kilometers per hour</value>
	public double WindKph { get; }
	/// <value>Maximum wind speed in miles per hour</value>
	public double WindMph { get; }
	/// <value>Wind direction in degrees</value>
	public int WindDegree { get; }
	/// <value>Wind direction as 16 point compass. e.g.: NSW</value>
	public string WindDirection { get; }
	/// <value>Pressure in millibars</value>
	public double PressureMb { get; }
	/// <value>Pressure in inches</value>
	public double PressureIn { get; }
	/// <value>Precipitation amount in millimeters</value>
	public double PrecipitationMm { get; }
	/// <value>Precipitation amount in inches</value>
	public double PrecipitationIn { get; }
	/// <value>Humidity as percentage</value>
	public int Humidity { get; }
	/// <value>Cloud cover as percentage</value>
	public int Clouds { get; }
	/// <value>Feels like temperature as celcius</value>
	public double FeelsLikeCelsius { get; }
	/// <value>Feels like temperature as fahrenheit</value>
	public double FeelsLikeFahrenheit { get; }
	/// <value>Windchill temperature in celcius</value>
	public double WindChillCelsius { get; }
	/// <value>Windchill temperature in fahrenheit</value>
	public double WindChillFahrenheit { get; }
	/// <value>Heat index in celcius</value>
	public double HeatIndexCelsius { get; }
	/// <value>Heat index in fahrenheit</value>
	public double HeatIndexFahrenheit { get; }
	/// <value>Dew point in celcius</value>
	public double DewPointCelsius { get; }
	/// <value>Dew point in fahrenheit</value>
	public double DewPointFahrenheit { get; }
	/// <value>Will it will rain or not</value>
	public bool WillItRain { get; }
	/// <value>Will it snow or not</value>
	public bool WillItSnow { get; }
	/// <value>Whether to show day condition icon or night icon</value>
	public bool IsDay { get; }
	/// <value>Visibility in kilometers</value>
	public double VisibilityKm { get; }
	/// <value>Visibility in miles</value>
	public double VisibilityMiles { get; }
	/// <value>Chance of rain as percentage</value>
	public int ChanceOfRain { get; }
	/// <value>Chance of snow as percentage</value>
	public int ChanceOfSnow { get; }
	/// <value>Wind gust in kilometers per hour</value>
	public double GustKph { get; }
	/// <value>Wind gust in miles per hour</value>
	public double GustMph { get; }
	/// <value>UV Index</value>
	public double UV { get; }
	/// <value><see cref="AirQuality"/> data</value>
	public AirQuality AirQuality { get; }

	internal ForecastHourly(dynamic jsonData, bool airQuality)
	{
		Valid = true;
		Date = jsonData.time;
		DateEpoch = jsonData.time_epoch;
		TemperatureCelsius = jsonData.temp_c;
		TemperatureFahrenheit = jsonData.temp_f;
		ConditionText = jsonData.condition.text;
		ConditionIconUrl = jsonData.condition.icon;
		ConditionCode = jsonData.condition.code;
		WindKph = jsonData.wind_kph;
		WindMph = jsonData.wind_mph;
		WindDegree = jsonData.wind_degree;
		WindDirection = jsonData.wind_dir;
		PressureMb = jsonData.pressure_mb;
		PressureIn = jsonData.pressure_in;
		PrecipitationMm = jsonData.precip_mm;
		PrecipitationIn = jsonData.precip_in;
		Humidity = jsonData.humidity;
		Clouds = jsonData.cloud;
		FeelsLikeCelsius = jsonData.feelslike_c;
		FeelsLikeFahrenheit = jsonData.feelslike_f;
		WindChillCelsius = jsonData.windchill_c;
		WindChillFahrenheit = jsonData.windchill_f;
		HeatIndexCelsius = jsonData.heatindex_c;
		HeatIndexFahrenheit = jsonData.heatindex_f;
		DewPointCelsius = jsonData.dewpoint_c;
		DewPointFahrenheit = jsonData.dewpoint_f;
		WillItRain = jsonData.will_it_rain;
		WillItSnow = jsonData.will_it_snow;
		IsDay = jsonData.is_day;
		VisibilityKm = jsonData.vis_km;
		VisibilityMiles = jsonData.vis_miles;
		ChanceOfRain = jsonData.chance_of_rain;
		ChanceOfSnow = jsonData.chance_of_snow;
		GustKph = jsonData.gust_kph;
		GustMph = jsonData.gust_mph;
		UV = jsonData.uv;
		if (airQuality)
		{
			AirQuality = new AirQuality(jsonData.air_quality);
			return;
		}
		AirQuality = default;
	}

	/// <summary>
	/// Generates string of all Members and their values
	/// </summary>
	/// <returns>Printable string of members and their values</returns>
	public override string ToString()
	{
		string s = string.Empty;

		foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this))
		{
			string name = descriptor.Name;
			object value = descriptor.GetValue(this) ?? "Null";
			s += $"{name} = {value}\n";
		}

		return s;
	}
}
