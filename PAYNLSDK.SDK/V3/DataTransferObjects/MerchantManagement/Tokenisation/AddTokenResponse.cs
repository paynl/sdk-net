using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.Idin.Responses;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.MerchantManagement.Tokenisation;

public class AddTokenResponse
{
	[JsonPropertyName("request")]
	public Request? Requests { get; set; }

	[JsonPropertyName("request")]
	public Token? Token { get; set; }
}
