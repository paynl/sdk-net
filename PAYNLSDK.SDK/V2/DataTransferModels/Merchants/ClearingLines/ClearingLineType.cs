using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Merchants.ClearingLines;

public class ClearingLineType
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("name")]
	public string? Name { get; set; }
}
