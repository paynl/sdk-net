using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Authentication.AuthenticationTokens;

public class AuthenticationTokenCreateRequest
{
	[JsonPropertyName("merchantCode")]
	public string? MerchantCode { get; set; }

	[JsonPropertyName("authenticationToken")]
	public AuthenticationToken AuthenticationToken { get; set; }

	[JsonPropertyName("ipFilter")]
	public IpFilter IpFilter { get; set; }
}
