using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Terminals;

public class TerminalSupplier
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("terminalId")]
    public string? TerminalId { get; set; }
}