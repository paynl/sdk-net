using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Services;

public class ServiceListResponse
{
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("services")]
    public List<Service>? Services { get; set; }
}