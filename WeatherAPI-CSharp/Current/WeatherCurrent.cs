namespace WeatherAPI_CSharp;

public class WeatherCurrent
{
	/// <summary>Local time when the real time data was updated.</summary>
	public string LastUpdated { get; }
	/// <summary>Local time when the real time data was updated in unix time.</summary>
	public long LastUpdatedEpoch { get; }
	/// <summary>Temperature in celsius</summary>
	public double TemperatureCelsius { get; }
	/// <summary>Temperature in fahrenheit</summary>
	public double TemperatureFahrenheit { get; }
	/// <summary>Feels like temperature in celsius</summary>
	public double FeelsLikeCelsius { get; }
	/// <summary>Feels like temperature in fahrenheit</summary>
	public double FeelsLikeFahrenheit { get; }
	/// <summary>Weather condition text</summary>
	public string ConditionText { get; }
	/// <summary>Weather icon url</summary>
	public string ConditionIconUrl { get; }
	/// <summary>Weather condition unique code.</summary>
	public int ConditionCode { get; }
	/// <summary>Wind speed in kilometer per hour</summary>
	public double WindKph { get; }
	/// <summary>Wind speed in miles per hour</summary>
	public double WindMph { get; }
	/// <summary>Wind direction in degrees</summary>
	public int WindDegree { get; }
	/// <summary>Wind direction as 16 point compass. e.g.: NSW</summary>
	public string WindDirection { get; }
	/// <summary>Pressure in millibars</summary>
	public double PressureMb { get; }
	/// <summary>Pressure in inches</summary>
	public double PressureIn {get; }
	/// <summary>Precipitation amount in millimeters</summary>
	public double PrecipitationMm { get; }
	/// <summary>Precipitation amount in inches</summary>
	public double PrecipitationIn { get; }
	/// <summary>Humidity as percentage</summary>
	public int Humidity { get; }
	/// <summary>Cloud cover as percentage</summary>
	public int Clouds { get; }
	/// <summary>Whether to show day condition icon or night icon</summary>
	public bool IsDay { get; }
	/// <summary>UV Index</summary>
	public double UV { get; }
	/// <summary>Wind gust in kilometer per hour</summary>
	public double GustKph { get; }
	/// <summary>Wind gust in miles per hour</summary>
	public double GustMph { get; }

	public WeatherCurrent(dynamic jsonData)
	{
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
	}
}