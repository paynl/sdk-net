using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.MerchantManagement;

public class Options
{
	[JsonPropertyName("schemeTransactionId")]
	public string? SchemeTransactionId { get; set; }

	/// <summary>
	/// By submitting a label for the token the consumer can distinguish the tokens if he has multiple cards
	/// </summary>
	[JsonPropertyName("label")]
	public string? Label { get; set; }
}
