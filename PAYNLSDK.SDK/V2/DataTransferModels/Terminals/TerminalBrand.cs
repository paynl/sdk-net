using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Terminals;

public class TerminalBrand
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("acquirer")]
    public string? Acquirer { get; set; }

    [JsonPropertyName("acquirerTid")]
    public string? AcquirerTid { get; set; }

    [JsonPropertyName("acquirerMid")]
    public string? AcquirerMid { get; set; }

    [JsonPropertyName("acquirerChecksum")]
    public string? AcquirerChecksum { get; set; }

    [JsonPropertyName("paymentTypes")]
    public List<string>? PaymentTypes { get; set; }

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