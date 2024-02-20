using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Transaction;

public class GetTransactionResponse
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("serviceCode")]
    public string? ServiceCode { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

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

    [JsonPropertyName("paymentMethod")]
    public PaymentMethod? PaymentMethod { get; set; }

    [JsonPropertyName("customer")]
    public Customer? Customer { get; set; }

    [JsonPropertyName("order")]
    public Order? Order { get; set; }

    [JsonPropertyName("stats")]
    public Stats? Stats { get; set; }

    [JsonPropertyName("transferData")]
    public object? TransferData { get; set; }

    [JsonPropertyName("expiresAt")]
    public DateTime? ExpiresAt { get; set; }

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
    
    public bool IsPaid()
    {
        return Status?.Code == (int)PaymentStatus.PAID;
    }
    
    public bool IsPending()
    {
        var status = Status?.Code;
        return status == (int)PaymentStatus.PENDING_1 ||
               status == (int)PaymentStatus.PENDING_2 ||
               status == (int)PaymentStatus.PENDING_3 ||
               status == (int)PaymentStatus.VERIFY;
    }
    
    public bool IsVerify()
    {
        return Status?.Code == (int)PaymentStatus.VERIFY || Status?.Phase == "VERIFY";
    }
}