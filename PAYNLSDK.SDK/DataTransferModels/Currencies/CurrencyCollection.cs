using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Currencies;

public class CurrencyCollection
{
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("currencies")]
    public List<Currency>? Currencies { get; set; }
}