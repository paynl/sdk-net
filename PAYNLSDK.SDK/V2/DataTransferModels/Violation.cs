using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels;

public class Violation
{
    [JsonPropertyName("propertyPath")]
    public string? PropertyPath { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }
}