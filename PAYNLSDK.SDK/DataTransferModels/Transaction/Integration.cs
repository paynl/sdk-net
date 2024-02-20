using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Transaction;

public class Integration
{
    [JsonPropertyName("testMode")]
    public bool TestMode { get; set; }
}