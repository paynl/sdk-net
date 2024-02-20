using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Trademarks;

public class CreateTrademarkRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("merchantCode")]
    public string? MerchantCode { get; set; }
}