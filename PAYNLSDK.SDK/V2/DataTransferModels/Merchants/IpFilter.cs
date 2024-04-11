using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

public class IpFilter
{
    [JsonPropertyName("Type")]
    public string? Type { get; set; }

    [JsonPropertyName("exceptionList")]
    public List<string>? ExceptionList { get; set; }
}
