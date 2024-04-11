using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

public class Status
{
    [JsonPropertyName("code")]
    public int? Code { get; set; } // The status code.

    [JsonPropertyName("action")]
    public string? Action { get; set; } // The state in which the transaction resides

    [JsonPropertyName("phase")]
    public string? Phase { get; set; } // The current phase in the transaction state
}