using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.ClearingAccounts;

public class ClearingAccountBrowseResponse
{
	[JsonPropertyName("total")]
	public int Total { get; set; }

	[JsonPropertyName("clearingAccounts")]
	public List<ClearingAccountResponse> ClearingAccounts { get; set; }

	[JsonPropertyName("_links")]
	public List<Link>? Links { get; set; }
}
