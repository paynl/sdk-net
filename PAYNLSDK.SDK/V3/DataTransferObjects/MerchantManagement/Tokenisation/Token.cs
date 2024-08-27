using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.MerchantManagement.Tokenisation;

public class Token
{
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	[JsonPropertyName("hash")]
	public string? Hash { get; set; }
}
