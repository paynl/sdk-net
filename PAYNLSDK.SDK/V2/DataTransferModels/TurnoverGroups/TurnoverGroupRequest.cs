using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.TurnoverGroups;

public class TurnoverGroupRequest
{
	[JsonPropertyName("merchantName")]
	public string? MerchantCode { get; set; }

	[JsonPropertyName("turnoverGroup")]
	public TurnoverGroup? TurnoverGroup { get; set; }
}
