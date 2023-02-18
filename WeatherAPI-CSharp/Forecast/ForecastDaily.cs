using System.ComponentModel;

namespace WeatherAPI_CSharp;

/// <summary>
/// Data class that holds daily data parsed from forecast api response
/// </summary>
public readonly struct ForecastDaily
{
	/// <value>Whether or not the API request was successfull</value>
	public bool Valid { get; }
	/// <value>Forecast date</value>
	public DateTime Date { get; }
	/// <value>Forecast date as unix time</value>
	public long DateEpoch { get; }
	/// <value>Maximum temperature in celsius for the day</value>
	public double MaxTemperatureCelsius { get; }
	/// <value>Maximum temperature in fahrenheit for the day</value>
	public double MaxTemperatureFahrenheit { get; }
	/// <value>Minimum temperature in celsius for the day</value>
	public double MinTemperatureCelsius { get; }
	/// <value>Minimum temperature in fahrenheit for the day</value>
	public double MinTemperatureFahrenheit { get; }
	/// <value>Average temperature in celsius for the day</value>
	public double AvgTemperatureCelsius { get; }
	/// <value>Average temperature in fahrenheit for the day</value>
	public double AvgTemperatureFahrenheit { get; }
	/// <value>Maximum wind speed in kilometer per hour</value>
	public double MaxWindKph { get; }
	/// <value>Maximum wind speed in miles per hour</value>
	public double MaxWindMph { get; }
	/// <value>Total precipitation in milimeters</value>
	public double TotalPrecipitationMm { get; }
	/// <value>Total precipitation in inches</value>
	public double TotalPrecipitationIn { get; }
	/// <value>Total snow in centimeters</value>
	public double TotalSnowCm { get; }
	/// <value>Average visibility in kilometer</value>
	public double AvgVisibilityKm { get; }
	/// <value>Average visibility in miles</value>
	public double AvgVisibilityMiles { get; }
	/// <value>Average humidity as percentage</value>
	public double AvgHumidity { get; }
	/// <value>Will it will rain or not</value>
	public bool WillItRain { get; }
	/// <value>Will it will snow or not</value>
	public bool WillItSnow { get; }
	/// <value>Chance of rain as percentage</value>
	public int ChanceOfRain { get; }
	/// <value>Chance of snow as percentage</value>
	public int ChanceOfSnow { get; }
	/// <value>Weather condition text</value>
	public string ConditionText { get; }
	/// <value>Weather icon url</value>
	public string ConditionIconUrl { get; }
	/// <value>Weather condition unique code</value>
	public int ConditionCode { get; }
	/// <value>UV Index</value>
	public double UV { get; }

	internal ForecastDaily(dynamic jsonData)
	{
		Valid = true;
		Date = jsonData.date;
		DateEpoch = jsonData.date_epoch;
		MaxTemperatureCelsius = jsonData.day.maxtemp_c;
		MaxTemperatureFahrenheit = jsonData.day.maxtemp_f;
		MinTemperatureCelsius = jsonData.day.mintemp_c;
		MinTemperatureFahrenheit = jsonData.day.mintemp_f;
		AvgTemperatureCelsius = jsonData.day.avgtemp_c;
		AvgTemperatureFahrenheit = jsonData.day.avgtemp_f;
		MaxWindKph = jsonData.day.maxwind_kph;
		MaxWindMph = jsonData.day.maxwind_mph;
		TotalPrecipitationMm = jsonData.day.totalprecip_mm;
		TotalPrecipitationIn = jsonData.day.totalprecip_in;
		TotalSnowCm = jsonData.day.totalsnow_cm;
		AvgVisibilityKm = jsonData.day.avgvis_km;
		AvgVisibilityMiles = jsonData.day.avgvis_miles;
		AvgHumidity = jsonData.day.avghumidity;
		WillItRain = jsonData.day.daily_will_it_rain == 0 ? false : true;
		WillItSnow = jsonData.day.daily_will_it_snow == 0 ? false : true;
		ChanceOfRain = jsonData.day.daily_chance_of_rain;
		ChanceOfSnow = jsonData.day.daily_chance_of_snow;
		ConditionText = jsonData.day.condition.text;
		ConditionIconUrl = jsonData.day.condition.icon;
		ConditionCode = jsonData.day.condition.code;
		UV = jsonData.day.uv;
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
