using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Transaction;

public class RefundTransactionRequest
{
    [JsonPropertyName("amount")]
    public Amount? Amount { get; set; }

    /// <summary>
    ///     Key is the ID of the product, value is the quantity
    /// </summary>
    [JsonPropertyName("products")]
    public Dictionary<string, int>? Products { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("processDate")]
    public DateTime? ProcessDate { get; set; }

    [JsonPropertyName("vatPercentage")]
    public float? VatPercentage { get; set; }

    [JsonPropertyName("exchangeUrl")]
    public string? ExchangeUrl { get; set; }
}