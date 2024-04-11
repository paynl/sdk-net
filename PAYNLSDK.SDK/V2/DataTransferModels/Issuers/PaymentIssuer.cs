using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.PaymentMethods;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Issuers;

public class PaymentIssuer
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("bic")]
    public string? Bic { get; set; }

    [JsonPropertyName("issuerId")]
    public string? IssuerId { get; set; }

    [JsonPropertyName("available")]
    public bool? Available { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("paymentMethod")]
    public PaymentMethod? PaymentMethod { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("modifiedAt")]
    public DateTime? ModifiedAt { get; set; }

    [JsonPropertyName("deletedAt")]
    public DateTime? DeletedAt { get; set; }
}
