using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Merchants;

public class IpFilter
{
    [JsonPropertyName("Type")]
    public string? Type { get; set; }

    [JsonPropertyName("exceptionList")]
    public List<string>? ExceptionList { get; set; }
}
