using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

public class Service
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("categoryCode")]
    public string? CategoryCode { get; set; }

    [JsonPropertyName("integrationCode")]
    public string? IntegrationCode { get; set; }

    [JsonPropertyName("publication")]
    public string? Publication { get; set; }
}