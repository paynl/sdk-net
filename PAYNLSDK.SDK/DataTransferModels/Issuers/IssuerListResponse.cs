using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Issuers;

public class IssuerListResponse
{
    [JsonPropertyName("total")]
    public int? Total { get; set; }
    
    [JsonPropertyName("issuers")]
    public List<PaymentIssuer>? Issuers { get; set; }
}