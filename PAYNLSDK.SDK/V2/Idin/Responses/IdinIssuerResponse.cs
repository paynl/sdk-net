using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.Idin.Responses;

public class IdinIssuerResponse
{
    [JsonPropertyName("request")]
    public Request? Request { get; set; }

    [JsonPropertyName("issuers")]
    public Dictionary<string, Issuer>? Issuers { get; set; }
}