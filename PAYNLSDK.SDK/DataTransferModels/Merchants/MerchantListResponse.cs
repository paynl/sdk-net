using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Merchants;

public class MerchantListResponse
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("merchants")]
    public List<MerchantResponse>? Merchants { get; set; }
}