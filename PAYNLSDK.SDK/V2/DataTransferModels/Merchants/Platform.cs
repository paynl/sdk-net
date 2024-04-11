using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

public class Platform
{
    [JsonPropertyName("loginAccount")]
    public bool? LoginAccount { get; set; }

    [JsonPropertyName("loginTpa")]
    public bool? LoginTpa { get; set; }

    [JsonPropertyName("authorisation")]
    public string? Authorisation { get; set; }

    [JsonPropertyName("all")]
    public bool? All { get; set; }

    [JsonPropertyName("authorisationGroups")]
    public List<string>? AuthorisationGroups { get; set; }
}