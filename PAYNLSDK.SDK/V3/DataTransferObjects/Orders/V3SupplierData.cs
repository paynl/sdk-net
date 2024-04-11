using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.Orders;

public class V3SupplierData
{
	[JsonPropertyName("contactDetails")]
	public V3ContactDetails ContactDetails { get; set; }

	[JsonPropertyName("invoiceAddress")]
	public V3Address InvoiceAddress { get; set; }

	[JsonPropertyName("shippingAddress")]
	public V3Address ShippingAddress { get; set; }
}
