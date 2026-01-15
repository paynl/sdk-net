using System.Text.Json.Serialization;
using PayNlSdk.Sdk.Utilities;

namespace PayNlSdk.Sdk.V3.Requests.Orders;

public class V3OrderInput
{
	/// <summary>
	/// 2 character long country code, e.g. NL for Netherlands.
	/// </summary>
	[JsonPropertyName("countryCode")]
	public string? CountryCode { get; set; }

	[JsonPropertyName("deliveryDate")]
	[JsonConverter(typeof(DateOnlyConverter))]
	public DateTime? DeliveryDate { get; set; }

	[JsonPropertyName("invoiceDate")]
	[JsonConverter(typeof(DateOnlyConverter))]
	public DateTime? InvoiceDate { get; set; }

	[JsonPropertyName("deliveryAddress")]
	public V3CreateOrderAddress DeliveryAddress { get; set; }

	[JsonPropertyName("invoiceAddress")]
	public V3CreateOrderAddress InvoiceAddress { get; set; }

	[JsonPropertyName("products")]
	public List<V3CreateOrderProduct>? Products { get; set; }
}
