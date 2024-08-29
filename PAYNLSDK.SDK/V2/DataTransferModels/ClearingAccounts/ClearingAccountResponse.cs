using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Authentication.AuthenticationTokens;
using PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

namespace PayNlSdk.Sdk.V2.DataTransferModels.ClearingAccounts;

public class ClearingAccountResponse
{
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	[JsonPropertyName("status")]
	public string? Status { get; set; }

	[JsonPropertyName("method")]
	public string? Method { get; set; }

	[JsonPropertyName("iban")]
	public Iban? Iban { get; set; }

	[JsonPropertyName("merchant")]
	public Merchant? Merchant { get; set; }

	[JsonPropertyName("createdAt")]
	public string? CreatedAt { get; set; }

	[JsonPropertyName("createdBy")]
	public string? CreatedBy { get; set; }

	[JsonPropertyName("modifiedAt")]
	public string? ModifiedAt { get; set; }

	[JsonPropertyName("modifiedBy")]
	public string? ModifiedBy { get; set; }

	[JsonPropertyName("deletedAt")]
	public string? DeletedAt { get; set; }

	[JsonPropertyName("deletedBy")]
	public string? DeletedBy { get; set; }

	[JsonPropertyName("_links")]
	public List<Link>? Links { get; set; }
}
