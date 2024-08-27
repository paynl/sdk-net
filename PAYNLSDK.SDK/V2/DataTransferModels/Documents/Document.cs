using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Documents;

public class Document
{
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	[JsonPropertyName("type")]
	public string? Type { get; set; }

	[JsonPropertyName("status")]
	public string? Status { get; set; }
}
