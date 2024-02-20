using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Merchants;

public class CreateMerchantRequest
{
    [JsonPropertyName("partner")]
    public CreateMerchantPartnerModel? Partner { get; set; }

    [JsonPropertyName("merchant")]
    public CreateMerchantModel? Merchant { get; set; }
}