using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels;

namespace PayNlSdk.Sdk.Utilities;

public class PaginatedLinks
{
	[JsonPropertyName("first")]
	public Link? FirstLink { get; set; }

	[JsonPropertyName("previous")]
	public Link? PreviousLink { get; set; }

	[JsonPropertyName("next")]
	public Link? NextLink { get; set; }

	[JsonPropertyName("last")]
	public Link? LastLink { get; set; }

	[JsonPropertyName("self")]
	public Link? Self { get; set; }
}
