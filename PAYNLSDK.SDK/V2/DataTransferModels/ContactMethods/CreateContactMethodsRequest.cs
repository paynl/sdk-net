using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.ContactMethods;

public class CreateContactMethodsRequest
{
	[JsonPropertyName("merchantCode")]
	public string? MerchantCode { get; set; }

	[JsonPropertyName("contactMethod")]
	public ContactMethod? ContactMethod { get; set; }
}
