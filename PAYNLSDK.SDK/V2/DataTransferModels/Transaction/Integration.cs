using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

public class Integration
{
    [JsonPropertyName("test")]
    public bool TestMode { get; set; }
}
