using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.Idin.Requests;

public class IdinAuthenticationRequest
{
    /// <summary>
    /// Your sales location starts with 'SL-' followed by 8 digits. You can find an overview of your sales location(s) at https://admin.pay.nl/websites
    /// </summary>
    [JsonPropertyName("serviceId")]
    public string? ServiceId { get; set; }

    /// <summary>
    /// Reference provided by the merchant.
    /// </summary>
    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    /// <summary>
    /// Identifier for an issuer/bank (e.g., RABONL2U).
    /// </summary>
    [JsonPropertyName("issuerId")]
    public string? IssuerId { get; set; }

    /// <summary>
    /// Array specifying which data needs to be retrieved. Possible values: 0: do not retrieve, 1: retrieve.
    /// </summary>
    [JsonPropertyName("data")]
    public IdinAuthenticationData? Data { get; set; }

    /// <summary>
    /// URL to which the consumer should return after authentication.
    /// </summary>
    [JsonPropertyName("returnUrl")]
    public string? ReturnUrl { get; set; }

    /// <summary>
    /// Language for the bank's screen. Possible values: nl / en.
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("exchangeUrl")]
    public string? ExchangeUrl { get; set; }
}
