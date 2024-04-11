using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

public class Iban
{
    [JsonPropertyName("iban")]
    public string? IbanNumber { get; set; }

    [JsonPropertyName("bic")]
    public string? Bic { get; set; }

    [JsonPropertyName("owner")]
    public string? Owner { get; set; }
}