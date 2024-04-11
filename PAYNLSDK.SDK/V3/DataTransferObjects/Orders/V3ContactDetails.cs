using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.Orders;

public class V3ContactDetails
{
	[JsonPropertyName("email")]
	public string Email { get; set; }

	[JsonPropertyName("firstName")]
	public string FirstName { get; set; }

	[JsonPropertyName("lastName")]
	public string LastName { get; set; }

	[JsonPropertyName("phoneNumber")]
	public string PhoneNumber { get; set; }
}
