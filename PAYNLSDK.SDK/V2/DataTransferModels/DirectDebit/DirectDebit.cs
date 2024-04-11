using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

namespace PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;

public class DirectDebit
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("paymentSessionId")]
    public int? PaymentSessionId { get; set; }

    [JsonPropertyName("processDate")]
    public string? ProcessDate { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("amount")]
    public Amount? Amount { get; set; }

    [JsonPropertyName("declined")]
    public Status? Declined { get; set; }

    [JsonPropertyName("status")]
    public Status? Status { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("bankAccount")]
    public PaymentBankAccount? BankAccount { get; set; }

    [JsonPropertyName("exchangeUrl")]
    public string? ExchangeUrl { get; set; }
}
