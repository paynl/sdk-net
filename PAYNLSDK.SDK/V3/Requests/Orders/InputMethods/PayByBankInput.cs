using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.Requests.Orders.InputMethods;

public class PayByBankInput : V3InputMethod
{
	[JsonPropertyName("issuer")]
	public string? Issuer { get; set; }

	[JsonPropertyName("country")]
	public string? Country { get; set; }

	[JsonPropertyName("debtorIban")]
	public string? DebtorIban { get; set; }

	[JsonPropertyName("psuId")]
	public string? PsuId { get; set; }
}
