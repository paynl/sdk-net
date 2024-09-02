using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.ClearingAccounts;

public class CreateClearingAccountRequest
{
	[JsonPropertyName("merchantCode")]
	public string? MerchantCode { get; set; }

	[JsonPropertyName("clearingAccount")]
	public ClearingAccountRequest? ClearingAccount { get; set; }
}
