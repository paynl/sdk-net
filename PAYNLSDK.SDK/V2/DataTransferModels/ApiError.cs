using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels;

public class ApiError
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("detail")]
    public string? Detail { get; set; }

    [JsonPropertyName("violations")]
    public List<Violation>? Violations { get; set; }
}