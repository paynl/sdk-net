using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Trademarks;

public class TrademarkListResponse
{
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("trademarks")]
    public List<TrademarkResponse>? Trademarks { get; set; }
}