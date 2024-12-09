using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.Orders;

public class V3CollectorCompany
{
	[JsonPropertyName("id")]
	public string Id { get; set; }
	[JsonPropertyName("name")]
	public string Name { get; set; }
	[JsonPropertyName("countryCode")]
	public string CountryCode { get; set; }
}