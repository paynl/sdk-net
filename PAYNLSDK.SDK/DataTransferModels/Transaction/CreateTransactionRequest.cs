using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Transaction;

public class CreateTransactionRequest
{
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

    [JsonPropertyName("amount")]
    public Amount? Amount { get; set; }

    [JsonPropertyName("paymentMethod")]
    public TransactionPaymentMethod? PaymentMethod { get; set; }

    [JsonPropertyName("integration")]
    public Integration? Integration { get; set; }

    [JsonPropertyName("customer")]
    public Customer? Customer { get; set; }

    [JsonPropertyName("order")]
    public Order? Order { get; set; }

    [JsonPropertyName("stats")]
    public Stats? Stats { get; set; }
}