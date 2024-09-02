using System.Text.Json.Serialization;
using PayNlSdk.Sdk.Utilities;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Merchants.ClearingLines;

public class ClearingLinesResponse
{
	[JsonPropertyName("total")]
	public int Total { get; set; }

	[JsonPropertyName("count")]
	public int Count { get; set; }

	[JsonPropertyName("clearingLines")]
	public List<ClearingLine>? ClearingLines { get; set; }

	[JsonPropertyName("_links")]
	public PaginatedLinks? Links { get; set; }
}
