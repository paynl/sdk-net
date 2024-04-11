using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.Orders;

public class V3OrderPayment
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("paymentMethod")]
	public PaymentMethod PaymentMethod { get; set; }

	[JsonPropertyName("customerType")]
	public string CustomerType { get; set; }

	[JsonPropertyName("customerKey")]
	public string CustomerKey { get; set; }

	[JsonPropertyName("customerId")]
	public string CustomerId { get; set; }

	[JsonPropertyName("ipAddress")]
	public string IpAddress { get; set; }

	[JsonPropertyName("secureStatus")]
	public bool SecureStatus { get; set; }

	[JsonPropertyName("paymentVerificationMethod")]
	public int PaymentVerificationMethod { get; set; }

	[JsonPropertyName("status")]
	public Status Status { get; set; }

	[JsonPropertyName("currencyAmount")]
	public Amount CurrencyAmount { get; set; }

	[JsonPropertyName("amount")]
	public Amount Amount { get; set; }

	[JsonPropertyName("authorizedAmount")]
	public Amount AuthorizedAmount { get; set; }

	[JsonPropertyName("capturedAmount")]
	public Amount CapturedAmount { get; set; }

	[JsonPropertyName("supplierData")]
	public V3SupplierData V3SupplierData { get; set; }
}
