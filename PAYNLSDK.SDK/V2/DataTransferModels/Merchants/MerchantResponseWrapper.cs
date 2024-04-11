using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

public class MerchantResponseWrapper
{
    [JsonPropertyName("merchant")]
    public MerchantResponse? Merchant { get; set; }
}