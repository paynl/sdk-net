using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Authentication;

public class Login
{
	[JsonPropertyName("inactivityExpire")]
	public int? InactivityExpire { get; set; }

	[JsonPropertyName("internalId")]
	public string? InternalId { get; set; }

	[JsonPropertyName("deviceId")]
	public string? DeviceId { get; set; }

	[JsonPropertyName("ipAddress")]
	public string? IpAddress { get; set; }

	[JsonPropertyName("userAgent")]
	public string? UserAgent { get; set; }
}
