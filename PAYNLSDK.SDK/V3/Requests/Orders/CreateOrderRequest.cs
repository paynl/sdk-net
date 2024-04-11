using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;
using PayNlSdk.Sdk.V3.DataTransferObjects;
using PayNlSdk.Sdk.V3.DataTransferObjects.Orders;
using PayNlSdk.Sdk.V3.Requests.Orders;

namespace PayNlSdk.Sdk.V3.Requests;

public class CreateOrderRequest
{
	[JsonPropertyName("amount")]
	public Amount? Amount { get; set; }

	[JsonPropertyName("paymentMethod")]
	public V3PaymentMethod? PaymentMethod { get; set; }

	[JsonPropertyName("integration")]
	public Integration? Integration { get; set; }

	[JsonPropertyName("customer")]
	public V3Customer? Customer { get; set; }

	[JsonPropertyName("order")]
	public V3Order? Order { get; set; }

	[JsonPropertyName("notification")]
	public V3Notification? Notification { get; set; }

	[JsonPropertyName("stats")]
	public Stats? Stats { get; set; }

	[JsonPropertyName("transferData")]
	public Dictionary<string, string>? TransferData { get; set; }

	[JsonPropertyName("serviceId")]
	public string? ServiceId { get; set; }

	[JsonPropertyName("description")]
	public string? Description { get; set; }

	[JsonPropertyName("reference")]
	public string? Reference { get; set; }

	[JsonPropertyName("expire")]
	public DateTime? Expire { get; set; }

	[JsonPropertyName("returnUrl")]
	public string? ReturnUrl { get; set; }

	[JsonPropertyName("exchangeUrl")]
	public string? ExchangeUrl { get; set; }
}
