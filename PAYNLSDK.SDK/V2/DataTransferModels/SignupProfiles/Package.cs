using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.SignupProfiles;

public class Package
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("translations")]
    public object? Translations { get; set; }

    [JsonPropertyName("partnerType")]
    public List<string>? PartnerType { get; set; }

    [JsonPropertyName("actionCode")]
    public string? ActionCode { get; set; }

    [JsonPropertyName("actionCodeValidUntil")]
    public DateTime? ActionCodeValidUntil { get; set; }

    [JsonPropertyName("contractPackage")]
    public string? ContractPackage { get; set; }

    [JsonPropertyName("monthlyFee")]
    public int? MonthlyFee { get; set; }

    [JsonPropertyName("discountPercentage")]
    public int? DiscountPercentage { get; set; }

    [JsonPropertyName("public")]
    public bool? Public { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("modifiedAt")]
    public DateTime? ModifiedAt { get; set; }

    [JsonPropertyName("deletedAt")]
    public DateTime? DeletedAt { get; set; }
}