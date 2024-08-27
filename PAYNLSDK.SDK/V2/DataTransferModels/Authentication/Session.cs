using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Authentication;

public class Session
{
	[JsonPropertyName("sessionCode")]
	public string? SessionCode { get; set; }

	[JsonPropertyName("handshake")]
	public string? Handshake { get; set; }

	[JsonPropertyName("internalId")]
	public string? InternalId { get; set; }

	[JsonPropertyName("licenseCode")]
	public string? LicenseCode { get; set; }

	[JsonPropertyName("redirectUrl")]
	public string? RedirectUrl { get; set; }
}
