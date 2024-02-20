using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Transaction;

public class CancelTransactionResponse
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    /// <summary>
    /// The ID of your service. You can find the service ID here: https://my.pay.nl/programs/programs
    /// </summary>
    [JsonPropertyName("serviceCode")]
    public string? ServiceCode { get; set;}

    /// <summary>
    ///  Is shown on the statement of the payer.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The merchant identification of this transaction. This field only allows alphanumeric characters
    /// </summary>
    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("amount")]
    public Amount? Amount { get; set; }

    [JsonPropertyName("amountConverted")]
    public Amount? AmountConverted { get; set; }

    [JsonPropertyName("amountPaid")]
    public Amount? AmountPaid { get; set; }

    [JsonPropertyName("amountRefunded")]
    public Amount? AmountRefunded { get; set; }
    
    [JsonPropertyName("status")]
    public Status? Status { get; set; }

    [JsonPropertyName("paymentData")]
    public PaymentData? PaymentData { get; set; }

    [JsonPropertyName("integration")]
    public Integration? Integration { get; set; }
    
    [JsonPropertyName("expiredAt")]
    public DateTime? ExpiredAt { get; set; }
    
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

    [JsonPropertyName("modifiedAt")]
    public DateTime? ModifiedAt { get; set; }

    [JsonPropertyName("modifiedBy")]
    public string? ModifiedBy { get; set; }

    [JsonPropertyName("deletedAt")]
    public DateTime? DeletedAt { get; set; }

    [JsonPropertyName("deletedBy")]
    public string? DeletedBy { get; set; }
}