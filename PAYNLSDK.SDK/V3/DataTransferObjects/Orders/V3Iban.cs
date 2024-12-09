using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.Orders;

public class V3Iban
{
	[JsonPropertyName("iban")]
	public string Iban { get; set; }
	[JsonPropertyName("bic")]
	public string Bic { get; set; }
	[JsonPropertyName("owner")]
	public string Owner { get; set; }
}