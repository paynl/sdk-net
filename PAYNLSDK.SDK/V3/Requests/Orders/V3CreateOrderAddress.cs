using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.Requests.Orders;

public class V3CreateOrderAddress
{
	[JsonPropertyName("firstName")]
	public string FirstName { get; set; }

	[JsonPropertyName("lastName")]
	public string LastName { get; set; }

	[JsonPropertyName("street")]
	public string Street { get; set; }

	[JsonPropertyName("streetNumber")]
	public string StreetNumber { get; set; }

	[JsonPropertyName("streetNumberExtension")]
	public string? StreetNumberExtension { get; set; }

	[JsonPropertyName("zipCode")]
	public string ZipCode { get; set; }

	/// <summary>
	/// 2 character long country code, e.g. NL for Netherlands.
	/// </summary>
	[JsonPropertyName("country")]
	public string Country { get; set; }

	[JsonPropertyName("region")]
	public string Region { get; set; }
}
