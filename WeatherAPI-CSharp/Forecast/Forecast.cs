using System.ComponentModel;

namespace WeatherAPI_CSharp;

/// <summary>
/// Data class that holds data parsed from realtime api response
/// </summary>
public readonly struct Forecast
{
	/// <value>Whether or not the API request was successfull</value>
	public bool Valid { get; }
	/// <value>Local time when the real time data was updated</value>
	public string LastUpdated { get; }
	/// <value>Local time when the real time data was updated in unix time</value>
	public long LastUpdatedEpoch { get; }
	/// <value>Temperature in celsius</value>
	public double TemperatureCelsius { get; }
	/// <value>Temperature in fahrenheit</value>
	public double TemperatureFahrenheit { get; }
	/// <value>Feels like temperature in celsius</value>
	public double FeelsLikeCelsius { get; }
	/// <value>Feels like temperature in fahrenheit</value>
	public double FeelsLikeFahrenheit { get; }
	/// <value>Weather condition text</value>
	public string ConditionText { get; }
	/// <value>Weather icon url</value>
	public string ConditionIconUrl { get; }
	/// <value>Weather condition unique code</value>
	public int ConditionCode { get; }
	/// <value>Wind speed in kilometer per hour</value>
	public double WindKph { get; }
	/// <value>Wind speed in miles per hour</value>
	public double WindMph { get; }
	/// <value>Wind direction in degrees</value>
	public int WindDegree { get; }
	/// <value>Wind direction as 16 point compass. e.g.: NSW</value>
	public string WindDirection { get; }
	/// <value>Pressure in millibars</value>
	public double PressureMb { get; }
	/// <value>Pressure in inches</value>
	public double PressureIn {get; }
	/// <value>Precipitation amount in millimeters</value>
	public double PrecipitationMm { get; }
	/// <value>Precipitation amount in inches</value>
	public double PrecipitationIn { get; }
	/// <value>Humidity as percentage</value>
	public int Humidity { get; }
	/// <value>Cloud cover as percentage</value>
	public int Clouds { get; }
	/// <value>Whether to show day condition icon or night icon</value>
	public bool IsDay { get; }
	/// <value>UV Index</value>
	public double UV { get; }
	/// <value>Wind gust in kilometer per hour</value>
	public double GustKph { get; }
	/// <value>Wind gust in miles per hour</value>
	public double GustMph { get; }
	/// <value><see cref="AirQuality"/> data</value>
	public AirQuality AirQuality { get; }

	internal Forecast(dynamic jsonData, bool airQuality)
	{
		Valid = true;
		LastUpdated = jsonData.last_updated;
		LastUpdatedEpoch = jsonData.last_updated_epoch;
		TemperatureCelsius = jsonData.temp_c;
		TemperatureFahrenheit = jsonData.temp_f;
		FeelsLikeCelsius = jsonData.feelslike_c;
		FeelsLikeFahrenheit = jsonData.feelslike_f;
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
		IsDay = jsonData.is_day == 0 ? false : true;
		UV = jsonData.uv;
		GustKph = jsonData.gust_kph;
		GustMph = jsonData.gust_mph;
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

		s += $"AQI Valid = {AirQuality.Valid}";

		return s;
	}
}