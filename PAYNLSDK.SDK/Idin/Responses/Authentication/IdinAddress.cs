using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.Idin.Responses.Authentication;

public class IdinAddress
{
    [JsonPropertyName("street")]
    public string? Street { get; set; }

    [JsonPropertyName("houseNo")]
    public string? HouseNo { get; set; }

    [JsonPropertyName("houseNoSuf")]
    public string? HouseNoSuf { get; set; }

    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("addressExtra")]
    public string? AddressExtra { get; set; }

    [JsonPropertyName("intAddressLine")]
    public string? IntAddressLine { get; set; }
}