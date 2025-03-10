using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.Idin.Responses;

public class IdinErrorResponse
{
	[JsonPropertyName("request")]
	public Request? Request { get; set; }

	[JsonPropertyName("trxid")]
	public string TrxId { get; set; }

	[JsonPropertyName("ec")]
	public string Ec { get; set; }

	[JsonPropertyName("issuerUrl")]
	public string IssuerUrl { get; set; }
}
