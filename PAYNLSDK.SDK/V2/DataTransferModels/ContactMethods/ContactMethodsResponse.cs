using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.ContactMethods;

public class ContactMethodsResponse
{
	[JsonPropertyName("total")]
	public int? Total { get; set; }

	[JsonPropertyName("contactMethods")]
	public List<ContactMethodResponse>? ContactMethods { get; set; }
}
