using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Transaction;

public class TransactionPaymentMethod
{
    /// <summary>
    /// ID of the payment method, EG 10 for iDEAL
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Sub ID for the payment method, EG bank code for iDEAL
    /// </summary>
    [JsonPropertyName("subId")]
    public string? SubId { get; set; }
}