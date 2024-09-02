using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Licenses;

public class LicensesBrowseResponse
{
	[JsonPropertyName("total")]
	public int Total { get; set; }

	[JsonPropertyName("licenses")]
	public List<LicenseResponse>? Licenses { get; set; }
}
