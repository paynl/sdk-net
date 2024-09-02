using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Licenses;

public class LicenseUpdateRequest
{
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	[JsonPropertyName("language")]
	public string? Language { get; set; }

	[JsonPropertyName("notificationGroup")]
	public NotificationGroup? NotificationGroup { get; set; }

	[JsonPropertyName("platform")]
	public Platform? Platform { get; set; }

	[JsonPropertyName("complianceData")]
	public ComplianceData? ComplianceData { get; set; }

	[JsonPropertyName("roles")]
	public Roles? Roles { get; set; }
}
