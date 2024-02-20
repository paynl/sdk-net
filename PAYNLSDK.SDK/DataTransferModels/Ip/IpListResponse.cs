using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Ip;

public class IpListResponse
{
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("ipaddresses")]
    public List<string>? IpAddresses { get; set; }
}
