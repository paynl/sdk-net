using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

public class Refund
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }
}