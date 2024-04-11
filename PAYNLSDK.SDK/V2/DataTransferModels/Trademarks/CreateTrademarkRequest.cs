using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Trademarks;

public class CreateTrademarkRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("merchantCode")]
    public string? MerchantCode { get; set; }
}