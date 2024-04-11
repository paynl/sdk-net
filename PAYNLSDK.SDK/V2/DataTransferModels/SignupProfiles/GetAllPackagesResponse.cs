using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.SignupProfiles;

public class GetAllPackagesResponse
{
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("packages")]
    public List<Package>? Packages { get; set; }
}