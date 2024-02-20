using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.DirectDebit;

public class Interval
{
    [JsonPropertyName("period")]
    public string? Period { get; set; }

    [JsonPropertyName("quantity")]
    public int? Quantity { get; set; }

    [JsonPropertyName("value")]
    public int? Value { get; set; }
}