using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Merchants.InvoiceLines;

public class Cost
{
	[JsonPropertyName("revenue")]
	public double? Revenue { get; set; }

	[JsonPropertyName("currency")]
	public string? Currency { get; set; }
}
