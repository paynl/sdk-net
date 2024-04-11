using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V3.Requests.Orders.InputMethods;

namespace PayNlSdk.Sdk.V3.Requests.Orders;

public class V3PaymentMethod
{
	[JsonPropertyName("input")]
	public V3InputMethod? Input { get; set; }

	[JsonPropertyName("id")]
	public int? Id { get; set; }

	[JsonPropertyName("optimize")]
	public List<string>? Optimize { get; set; }
}
