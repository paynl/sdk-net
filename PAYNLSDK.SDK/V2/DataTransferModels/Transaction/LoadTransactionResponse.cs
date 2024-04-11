using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Shared;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

public class LoadTransactionResponse
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

    [JsonPropertyName("returnUrl")]
    public string? ReturnUrl { get; set; }

    [JsonPropertyName("amount")]
    public Amount? Amount { get; set; }

    [JsonPropertyName("status")]
    public Status? Status { get; set; }

    [JsonPropertyName("integration")]
    public Integration? Integration { get; set; }

    [JsonPropertyName("merchant")]
    public SmallMerchantInfo? Merchant { get; set; }

    [JsonPropertyName("tradeName")]
    public TradeName? TradeName { get; set; }

    [JsonPropertyName("layout")]
    public Layout? Layout { get; set; }

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
}