using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

public class Integration
{
    [JsonPropertyName("testMode")]
    public bool TestMode { get; set; }
}
