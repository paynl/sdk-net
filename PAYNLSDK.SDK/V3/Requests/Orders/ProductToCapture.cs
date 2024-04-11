using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.Requests.Orders;

public class ProductToCapture
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("quantity")]
	public int Quantity { get; set; }
}
