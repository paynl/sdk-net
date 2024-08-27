using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Services;

public class PaymentLinkResponse
{
	[JsonPropertyName("url")]
	public string? Url { get; set; }

	[JsonPropertyName("securityMode")]
	public int? SecurityMode { get; set; }
}
