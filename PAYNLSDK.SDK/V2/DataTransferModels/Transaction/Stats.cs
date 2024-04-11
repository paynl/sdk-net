using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

public class Stats
{
    [JsonPropertyName("info")]
    public string? Info { get; set; } // The used info code which can be tracked in the stats.

    [JsonPropertyName("tool")]
    public string? Tool { get; set; } // The used tool code which can be tracked in the stats.

    [JsonPropertyName("object")]
    public string? Object { get; set; } // The object which can be tracked in stats.

    [JsonPropertyName("extra1")]
    public string? Extra1 { get; set; } // The first free value which can be tracked in the stats.

    [JsonPropertyName("extra2")]
    public string? Extra2 { get; set; } // The second free value which can be tracked in the stats.

    [JsonPropertyName("extra3")]
    public string? Extra3 { get; set; } // The third free value which can be tracked in the stats.

    [JsonPropertyName("domainId")]
    public string? DomainId { get; set; } // The ID of the duplicate content URL.
}