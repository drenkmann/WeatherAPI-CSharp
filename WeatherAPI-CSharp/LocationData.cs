using System.ComponentModel;

namespace WeatherAPI_CSharp;

public readonly struct LocationData
{
	/// <value>Whether or not the API request was successfull</value>
	public bool Valid { get; }
	/// <value>IP address</value>
	public string Ip { get; }
	/// <value>IP address type (ipv4/ipv6)</value>
	public string Type { get; }
	/// <value>Continent code</value>
	public string ContinentCode { get; }
	/// <value>Continent name</value>
	public string ContinentName { get; }
	/// <value>Country code</value>
	public string CountryCode { get; }
	/// <value>Country name</value>
	public string CountryName { get; }
	/// <value>Weather the country is in the EU</value>
	public bool IsEu { get; }
	/// <value>Geoname ID</value>
	public string GeonameId { get; }
	/// <value>City name</value>
	public string City { get; }
	/// <value>Region name</value>
	public string Region { get; }
	/// <value>Latitude in decimal degrees</value>
	public double Latitude { get; }
	/// <value>Longitude in decimal degrees</value>
	public double Longitude { get; }
	/// <value>Time zone name</value>
	public string Timezone { get; }

	internal LocationData(dynamic jsonData)
	{
		Valid = true;
		Ip = jsonData.ip;
		Type = jsonData.type;
		ContinentCode = jsonData.continent_code;
		ContinentName = jsonData.continent_name;
		CountryCode = jsonData.country_code;
		CountryName = jsonData.country_name;
		IsEu = jsonData.is_eu;
		GeonameId = jsonData.geoname_id;
		City = jsonData.city;
		Region = jsonData.region;
		Latitude = jsonData.lat;
		Longitude = jsonData.lon;
		Timezone = jsonData.tz_id;
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
