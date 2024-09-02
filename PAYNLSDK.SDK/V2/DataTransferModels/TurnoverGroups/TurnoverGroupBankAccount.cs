using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

namespace PayNlSdk.Sdk.V2.DataTransferModels.TurnoverGroups;

public class TurnoverGroupBankAccount
{
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	[JsonPropertyName("status")]
	public string? Status { get; set; }

	[JsonPropertyName("method")]
	public string? Method { get; set; }

	[JsonPropertyName("iban")]
	public Iban? Iban { get; set; }
}
