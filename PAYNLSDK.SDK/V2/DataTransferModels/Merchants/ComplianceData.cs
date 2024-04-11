using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

public class ComplianceData
{
    [JsonPropertyName("dateOfBirth")]
    public DateTime? DateOfBirth { get; set; }

    [JsonPropertyName("nationality")]
    public string? Nationality { get; set; }

    [JsonPropertyName("authorizedToSign")]
    public string? AuthorizedToSign { get; set; }

    [JsonPropertyName("shared")]
    public bool? Shared { get; set; }

    [JsonPropertyName("pep")]
    public bool? Pep { get; set; }

    [JsonPropertyName("pepDescription")]
    public string? PepDescription { get; set; }

    [JsonPropertyName("ubo")]
    public string? Ubo { get; set; }

    [JsonPropertyName("direct")]
    public string? Direct { get; set; }

    [JsonPropertyName("uboPercentage")]
    public int? UboPercentage { get; set; }

    [JsonPropertyName("relationshipDescription")]
    public string? RelationshipDescription { get; set; }
}