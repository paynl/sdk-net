using System.Text.Json.Serialization;
using PayNlSdk.Sdk.DataTransferModels.Transaction;

namespace PayNlSdk.Sdk.DataTransferModels.Vouchers;

public class VoucherCreationRequest
{
    [JsonPropertyName("transaction")]
    public Transaction? Transaction { get; set; }

    [JsonPropertyName("voucher")]
    public Voucher? Voucher { get; set; }

    [JsonPropertyName("customer")]
    public Customer? Customer { get; set; }

    [JsonPropertyName("order")]
    public Order? Order { get; set; }

    [JsonPropertyName("stats")]
    public Stats? Stats { get; set; }
}