using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.Orders;

public class V3CollectorAccount
{
	[JsonPropertyName("iban")]
	public V3Iban Iban { get; set; }

	[JsonPropertyName("method")]
	public string Method { get; set; }
}