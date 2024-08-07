using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Ip;

public class IpListResponse
{
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("ipAddresses")]
    public List<string>? IpAddresses { get; set; }
}
