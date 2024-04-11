using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Terminals;

public class TerminalLocation
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("streetName")]
    public string? StreetName { get; set; }

    [JsonPropertyName("streetNumber")]
    public string? StreetNumber { get; set; }

    [JsonPropertyName("zipCode")]
    public string? ZipCode { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("regionCode")]
    public string? RegionCode { get; set; }

    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }
}