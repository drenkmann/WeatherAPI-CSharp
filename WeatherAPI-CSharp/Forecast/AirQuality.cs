using System.ComponentModel;

namespace WeatherAPI_CSharp;

/// <summary>
/// Data class that holds air quality data
/// </summary>
public readonly struct AirQuality
{
	/// <value>Whether or not the air quality request was successfull</value>
	public bool Valid { get; }
	/// <value>Carbon Monoxide (μg/m3)</value>
	public float CO { get; }
	/// <value>Ozone (μg/m3)</value>
	public float O3 { get; }
	/// <value>Nitrogen dioxide (μg/m3)</value>
	public float NO2 { get; }
	/// <value>Sulphur dioxide (μg/m3)</value>
	public float SO2 { get; }
	/// <value>PM2.5 (μg/m3)</value>
	public float PM25 { get; }
	/// <value>PM10 (μg/m3)</value>
	public float PM10 { get; }
	/// <value>US - EPA standard</value>
	public int UsEpaIndex { get; }
	/// <value>UK Defra Index</value>
	public int GbDefraIndex { get; }
	/// <value>US - EPA standard Meaning</value>
	public string UsIndexMeaning { get; }
	/// <value>UK Defra Index Meaning</value>
	public string GbIndexMeaning { get; }

	internal AirQuality(dynamic jsonData)
	{
		UsEpaIndex = 0;
		GbDefraIndex = 0;

		Valid = true;
		CO = jsonData.co;
		O3 = jsonData.o3;
		NO2 = jsonData.no2;
		SO2 = jsonData.so2;
		PM25 = jsonData.pm2_5;
		PM10 = jsonData.pm10;
		UsIndexMeaning = UsEpaIndex switch
		{
			1 => "Good",
			2 => "Moderate",
			3 => "Unhealthy for sensitive group",
			4 => "Unhealthy",
			5 => "Very unhealthy",
			6 => "Hazardous",
			_ => "Unknown"
		};
		GbIndexMeaning = GbDefraIndex switch
		{
			1 or 2 or 3 => "Low",
			4 or 5 or 6 => "Moderate",
			7 or 8 or 9 => "High",
			10 => "Very High",
			_ => "Unknown"
		};

		foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(jsonData))
		{
			string name = descriptor.Name;
			object value = descriptor.GetValue(jsonData);

			if (name == "us-epa-index")
				UsEpaIndex = int.Parse(value.ToString()!);
			else if (name == "gb-defra-index")
				GbDefraIndex = int.Parse(value.ToString()!);
		}
	}
}
