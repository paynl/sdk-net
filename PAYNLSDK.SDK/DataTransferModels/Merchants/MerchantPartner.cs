using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Merchants;

public class MerchantPartner
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("accessToMerchant")]
    public bool? AccessToMerchant { get; set; }
}