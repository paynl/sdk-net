using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;

public class CreateMandateRequest
{
	/// <summary>
	/// Your sales location begins with ‘SL-’ followed by 8 digits. An overview of your sales locations can be found at https://admin.pay.nl/websites
	/// </summary>
	[JsonPropertyName("serviceId")]
	public string? ServiceId { get; set; }

	/// <summary>
	/// Amount in cents, €3.50 is therefore 350
	/// </summary>
	[JsonPropertyName("amount")]
	public int Amount { get; set; }

	/// <summary>
	/// Client name
	/// </summary>
	[JsonPropertyName("bankaccountHolder")]
	public string? Bankaccountholder { get; set; }

	/// <summary>
	/// Client’s IBAN
	/// </summary>
	[JsonPropertyName("bankaccountNumber")]
	public string? BankaccountNumber { get; set; }

	/// <summary>
	/// Client’s BIC
	/// </summary>
	[JsonPropertyName("bankaccountBic")]
	public string? BankaccountBic { get; set; }

	/// <summary>
	/// The date upon which the direct debit must be processed (dd-mm-yyyy)
	/// </summary>
	[JsonPropertyName("processDate")]
	public string? ProcessDate { get; set; }

	/// <summary>
	/// Description of the direct debit order
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Currency according to ISO 4217 (three-letter code), EUR will be used by default. An overview can be viewed at https://admin.pay.nl/data/currencies
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// The exchange URL (https://docs.pay.nl/developers?language=en#exchange) to be used for this direct debit
	/// </summary>
	[JsonPropertyName("exchangeUrl")]
	public string? ExchangeUrl { get; set; }

	/// <summary>
	/// Client’s IP address
	/// </summary>
	[JsonPropertyName("ipAddress")]
	public string? IpAddress { get; set; }

	/// <summary>
	/// Client’s email address
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// The id of the promotor (webmaster)
	/// </summary>
	[JsonPropertyName("promotor")]
	public int PromotorId { get; set; }

	/// <summary>
	/// Variable 'tool' which can be traced in the statistics
	/// </summary>
	[JsonPropertyName("info")]
	public string? Info { get; set; }

	/// <summary>
	/// Variable 'info' which can be traced in the statistics
	/// </summary>
	[JsonPropertyName("tool")]
	public string? Tool { get; set; }

	/// <summary>
	/// Variable 'object' which can be traced in the statistics
	/// </summary>
	[JsonPropertyName("object")]
	public string? Object { get; set; }

	/// <summary>
	/// Variable 'extra1' which can be traced in the statistics
	/// </summary>
	[JsonPropertyName("extra1")]
	public string? Extra1 { get; set; }

	/// <summary>
	/// Variable 'extra2' which can be traced in the statistics
	/// </summary>
	[JsonPropertyName("extra2")]
	public string? Extra2 { get; set; }

	/// <summary>
	/// Variable 'extra3' which can be traced in the statistics
	/// </summary>
	[JsonPropertyName("extra3")]
	public string? Extra3 { get; set; }
}
