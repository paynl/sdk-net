using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

public class AuthenticationToken
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("authorisation")]
    public string? Authorisation { get; set; }

    [JsonPropertyName("all")]
    public bool? All { get; set; }

    [JsonPropertyName("authorisationGroups")]
    public List<string>? AuthorisationGroups { get; set; }

    [JsonPropertyName("ipFilter")]
    public IpFilter? IpFilter { get; set; }
}