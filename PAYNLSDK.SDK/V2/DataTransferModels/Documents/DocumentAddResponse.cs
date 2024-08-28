using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Documents;

public class DocumentAddResponse
{
	[JsonPropertyName("document")]
	public Document? Document { get; set; }

	[JsonPropertyName("_links")]
	public List<Link>? Links { get; set; }
}
