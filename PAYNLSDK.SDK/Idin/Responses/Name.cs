using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.Idin.Responses;

public class Name
{
    [JsonPropertyName("prefLastName")]
    public string? PrefLastName { get; set; }

    [JsonPropertyName("prefLastNamePrefix")]
    public string? PrefLastNamePrefix { get; set; }

    [JsonPropertyName("legalLastName")]
    public string? LegalLastName { get; set; }

    [JsonPropertyName("legalLastNamePrefix")]
    public string? LegalLastNamePrefix { get; set; }

    [JsonPropertyName("partnerLastName")]
    public string? PartnerLastName { get; set; }

    [JsonPropertyName("partnerLastNamePrefix")]
    public string? PartnerLastNamePrefix { get; set; }

    [JsonPropertyName("initials")]
    public string? Initials { get; set; }

    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }
}