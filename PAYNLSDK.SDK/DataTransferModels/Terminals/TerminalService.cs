using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Terminals;

public class TerminalService
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}