using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;

public class FlexibleDirectDebitResponse
{
	/// <summary>
	/// The direct debit identifier.
	/// </summary>
	[JsonPropertyName("result")]
	public string? DebitOrderId { get; set; }

	[JsonPropertyName("request")]
	public Error? Request { get; set; }
}
