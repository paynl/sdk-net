using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Services;

public class PaymentLinkRequest
{
	/// <summary>
	/// 0: URL, amount and variables can be changed
	/// 1: Amount is fixed. URL and variables can be changed
	/// 2: Pre filled variable can be changed. Amount is fixed
	/// 3: URL, amount and variables are fixed. Only empty variables can be filled
	/// </summary>
	[JsonPropertyName("securityMode")]
	public int? SecurityMode { get; set; }

	/// <summary>
	/// The country code consisting of 2 uppercase letters
	/// </summary>
	[JsonPropertyName("countryCode")]
	public string? CountryCode { get; set; }

	/// <summary>
	/// The language code supplied needs to be a locale in i18n format.
	/// The available languages can be retrieved with the Core Data API Languages (https://developer.pay.nl/reference/get_languages) where the hostedPaymentPageLanguageAvailable flag is set to 'True'
	/// </summary>
	[JsonPropertyName("language")]
	public string? Language { get; set; }

	[JsonPropertyName("amountMin")]
	public Amount? AmountMin { get; set; }

	[JsonPropertyName("amount")]
	public Amount? Amount { get; set; }

	[JsonPropertyName("stats")]
	public Stats? Stats { get; set; }
}
