using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.TurnoverGroups;

public class TurnoverGroupBrowseResponse
{
	[JsonPropertyName("total")]
	public int? Total { get; set; }

	[JsonPropertyName("turnoverGroups")]
	public List<TurnoverGroupResponse>? TurnoverGroups { get; set; }
}
