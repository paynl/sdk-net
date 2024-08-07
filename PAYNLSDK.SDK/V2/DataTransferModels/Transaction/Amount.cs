using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

public class Amount
{
    // Amount in cents
    [JsonPropertyName("value")]
    public int? Value { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }
}