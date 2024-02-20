using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.SignupProfiles;

public class GetAllPackagesResponse
{
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("packages")]
    public List<Package>? Packages { get; set; }
}