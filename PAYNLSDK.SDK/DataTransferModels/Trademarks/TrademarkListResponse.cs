using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Trademarks;

public class TrademarkListResponse
{
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("trademarks")]
    public List<TrademarkResponse>? Trademarks { get; set; }
}