using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.Requests.Orders.InputMethods;

public class SprayPayInput
{
	[JsonPropertyName("gender")]
	public string? Gender { get; set; }

	[JsonPropertyName("country")]
	public string? Country { get; set; }

	[JsonPropertyName("initials")]
	public string? Initials { get; set; }

	[JsonPropertyName("firstName")]
	public string? FirstName { get; set; }

	[JsonPropertyName("lastName")]
	public string? LastName { get; set; }

	[JsonPropertyName("streetName")]
	public string? StreetName { get; set; }

	[JsonPropertyName("houseNumber")]
	public string? HouseNumber { get; set; }

	[JsonPropertyName("houseNumberAddition")]
	public string? HouseNumberAddition { get; set; }

	[JsonPropertyName("postalCode")]
	public string? PostalCode { get; set; }

	[JsonPropertyName("city")]
	public string? City { get; set; }

	[JsonPropertyName("email")]
	public string? Email { get; set; }

	[JsonPropertyName("phoneNumber")]
	public string? PhoneNumber { get; set; }
}
