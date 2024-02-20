using System.Text.Json.Serialization;
using PayNlSdk.Sdk.DataTransferModels.Transaction;

namespace PayNlSdk.Sdk.DataTransferModels.Merchants;

public class CreateMerchantModel
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

    /// <summary>
    /// The country code consisting of 2 uppercase letters
    /// </summary>
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

    /// <summary>
    ///     The language code supplied needs to be a locale in i18n format.
    ///     The available languages can be retrieved with the Core Data API Languages
    ///     (https://developer.pay.nl/reference/get_languages) where the contractLanguageAvailable flag is set to 'True'
    /// </summary>
    [JsonPropertyName("contractLanguage")]
    public string? ContractLanguage { get; set; }

    [JsonPropertyName("clearingAccounts")]
    public List<ClearingAccount>? ClearingAccounts { get; set; }

    [JsonPropertyName("visitAddress")]
    public Address? VisitAddress { get; set; }

    [JsonPropertyName("authenticationTokens")]
    public List<AuthenticationToken>? AuthenticationTokens { get; set; }

    [JsonPropertyName("persons")]
    public List<Person>? Persons { get; set; }

    [JsonPropertyName("service")]
    public Service? Service { get; set; }
}