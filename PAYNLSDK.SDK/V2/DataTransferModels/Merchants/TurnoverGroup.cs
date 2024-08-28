using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

public class TurnoverGroup
{
	[JsonPropertyName("code")]
	public string Code { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }
}
