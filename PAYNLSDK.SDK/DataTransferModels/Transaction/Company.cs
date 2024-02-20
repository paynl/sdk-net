using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.DataTransferModels.Transaction;

public class Company
{
    [JsonPropertyName("name")]
    public string? Name { get; set; } // The name of your merchant.

    [JsonPropertyName("coc")]
    public string? CoC { get; set; } // Your Chamber of Commerce registration number. This format differs per country.

    [JsonPropertyName("vat")]
    public string? VAT { get; set; } // Value added tax identification number (VAT identification number).

    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; } // The country code consisting of 2 uppercase letters.
}