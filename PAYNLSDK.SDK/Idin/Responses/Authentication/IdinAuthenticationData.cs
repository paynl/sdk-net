using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.Idin.Responses.Authentication;

public class IdinAuthenticationData
{
    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("statusMessage")]
    public string? StatusMessage { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public Name? Name { get; set; }

    [JsonPropertyName("address")]
    public IdinAddress? Address { get; set; }

    [JsonPropertyName("isEighteen")]
    public string? IsEighteen { get; set; }

    [JsonPropertyName("dateOfBirth")]
    public string? DateOfBirth { get; set; }

    [JsonPropertyName("gender")]
    public string? Gender { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }
}