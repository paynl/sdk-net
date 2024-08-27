using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

namespace PayNlSdk.Sdk.V3.Requests.Orders;

public class V3CreateOrderProduct
{
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Product type, get available options for your account using <see>
	///     <cref>https://developer.pay.nl/reference/get_product_types</cref>
	/// </see>
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	[JsonPropertyName("quantity")]
	public int? Quantity { get; set; }

	[JsonPropertyName("price")]
	public Amount? Price { get; set; }

	[JsonPropertyName("vatPercentage")]
	public int? VatPercentage { get; set; }
}
