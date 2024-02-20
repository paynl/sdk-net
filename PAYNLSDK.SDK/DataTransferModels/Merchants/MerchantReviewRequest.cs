using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Merchants;

public class MerchantReviewRequest
{
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("indicator")]
    public string? Indicator { get; set; }

    [JsonPropertyName("settlement")]
    public string? Settlement { get; set; }
}