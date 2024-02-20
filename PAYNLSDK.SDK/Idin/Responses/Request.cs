using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.Idin.Responses;

public class Request
{
    [JsonPropertyName("result")]
    public string? Result { get; set; }

    [JsonPropertyName("errorId")]
    public string? ErrorId { get; set; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }
}
