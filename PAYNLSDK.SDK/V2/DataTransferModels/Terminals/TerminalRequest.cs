using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Terminals;

public class TerminalRequest
{
	[JsonPropertyName("serviceId")]
	public string? ServiceId { get; set; }

	[JsonPropertyName("activationCode")]
	public string? ActivationCode { get; set; }

	[JsonPropertyName("name")]
	public string? Name { get; set; }

	[JsonPropertyName("description")]
	public string? Description { get; set; }
}
