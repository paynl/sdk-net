using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;

public class FlexibleDirectDebitRequest
{
	/// <summary>
	/// The Id received from the create mandate end point.
	/// </summary>
	[JsonPropertyName("MandateId")]
	public string? MandateId { get; set; }

	/// <summary>
	/// The amount of the direct debit. If no amount is entered, the amount of the previous direct debit will be used.
	/// </summary>
	[JsonPropertyName("amount")]
	public int Amount { get; set; }

	/// <summary>
	/// Description of the direct debit order
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// The date upon which the direct debit must be processed (dd-mm-yyyy)
	/// </summary>
	[JsonPropertyName("processDate")]
	public string? ProcessDate { get; set; }

	/// <summary>
	/// Indicates that this is the final direct debit order; the mandate will then be invalid.
	/// </summary>
	[JsonPropertyName("last")]
	public bool Last { get; set; }
}
