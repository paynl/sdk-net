using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Terminals;

public class TerminalSupplier
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("terminalId")]
    public string? TerminalId { get; set; }
}
