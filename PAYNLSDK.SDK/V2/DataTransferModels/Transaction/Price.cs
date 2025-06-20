using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

public class Price
{
	[JsonPropertyName("value")]
	public int? Value { get; set; }
}
