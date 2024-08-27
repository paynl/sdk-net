using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Documents;

public class Links
{
	[JsonPropertyName("href")]
	public string? Href { get; set; }

	[JsonPropertyName("rel")]
	public string? Rel { get; set; }

	[JsonPropertyName("type")]
	public string? Type { get; set; }
}
