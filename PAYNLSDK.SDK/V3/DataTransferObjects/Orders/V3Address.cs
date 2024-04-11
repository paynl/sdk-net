using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.Orders;

public class V3Address
{
	[JsonPropertyName("firstName")]
	public string FirstName { get; set; }

	[JsonPropertyName("lastName")]
	public string LastName { get; set; }

	[JsonPropertyName("streetName")]
	public string StreetName { get; set; }

	[JsonPropertyName("streetNumber")]
	public string StreetNumber { get; set; }

	[JsonPropertyName("streetNumberAddition")]
	public string StreetNumberAddition { get; set; }

	[JsonPropertyName("zipCode")]
	public string ZipCode { get; set; }

	[JsonPropertyName("city")]
	public string City { get; set; }

	[JsonPropertyName("countryCode")]
	public string CountryCode { get; set; }

	[JsonPropertyName("regionCode")]
	public string RegionCode { get; set; }

	[JsonPropertyName("street")]
	public string Street { get; set; }

	[JsonPropertyName("houseNumber")]
	public string HouseNumber { get; set; }

	[JsonPropertyName("addition")]
	public string Addition { get; set; }

	[JsonPropertyName("postalCode")]
	public string PostalCode { get; set; }

	[JsonPropertyName("companyName")]
	public string CompanyName { get; set; }

	[JsonPropertyName("countryName")]
	public string CountryName { get; set; }
}
