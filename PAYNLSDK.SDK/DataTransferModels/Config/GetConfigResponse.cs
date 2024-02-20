using System.Text.Json.Serialization;
using PayNlSdk.Sdk.DataTransferModels.Transaction;

namespace PayNlSdk.Sdk.DataTransferModels.Config;

public class GetConfigResponse
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("secret")]
    public string? Secret { get; set; }

    [JsonPropertyName("testMode")]
    public bool? TestMode { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("mcc")]
    public int? Mcc { get; set; }

    [JsonPropertyName("layout")]
    public Layout? Layout { get; set; }

    [JsonPropertyName("tradeName")]
    public TradeName? TradeName { get; set; }

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

    [JsonPropertyName("tguList")]
    public List<Tgu>? TguList { get; set; }
}
