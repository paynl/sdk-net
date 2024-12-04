using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.Orders;

public class V3Customer
{
	[JsonPropertyName("email")]
	public string Email { get; set; }

	[JsonPropertyName("firstname")]
	public string Firstname { get; set; }

	[JsonPropertyName("lastname")]
	public string Lastname { get; set; }

	[JsonPropertyName("birthDate")]
	public DateTime DateOfBirth { get; set; }

	[JsonPropertyName("gender")]
	public string Gender { get; set; }

	[JsonPropertyName("phone")]
	public string Phone { get; set; }

	[JsonPropertyName("locale")]
	public string Locale { get; set; }

	[JsonPropertyName("ipAddress")]
	public string IpAddress { get; set; }

	[JsonPropertyName("reference")]
	public string Reference { get; set; }

	[JsonPropertyName("company")]
	public V3Company Company { get; set; }
}
