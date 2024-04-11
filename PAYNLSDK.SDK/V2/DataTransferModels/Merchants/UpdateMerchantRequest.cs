using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

public class UpdateMerchantRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("publicName")]
    public string? PublicName { get; set; }

    [JsonPropertyName("coc")]
    public string? Coc { get; set; }

    [JsonPropertyName("vat")]
    public string? Vat { get; set; }

    [JsonPropertyName("companyTypeId")]
    public string? CompanyTypeId { get; set; }

    // The country code consisting of 2 uppercase letters
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

    /// <summary>
    ///     The language code supplied needs to be a locale in i18n format.
    ///     The available languages can be retrieved with the Core Data API Languages
    ///     (https://developer.pay.nl/reference/get_languages) where the contractLanguageAvailable flag is set to 'True'
    /// </summary>
    [JsonPropertyName("contractLanguage")]
    public string? ContractLanguage { get; set; }
    
    [JsonPropertyName("visitAddress")]
    public Address? VisitAddress { get; set; }

    [JsonPropertyName("postalAddress")]
    public Address? PostalAddress { get; set; }

    [JsonPropertyName("suspendedAt")]
    public DateTime? SuspendedAt { get; set; }

    [JsonPropertyName("reviewRequest")]
    public MerchantReviewRequest? ReviewRequest { get; set; }
}