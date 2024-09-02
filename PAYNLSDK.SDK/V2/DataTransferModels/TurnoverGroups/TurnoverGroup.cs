using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.TurnoverGroups;

public class TurnoverGroup
{
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	[JsonPropertyName("bankaccountCode")]
	public string? BankaccountCode { get; set; }

	[JsonPropertyName("description")]
	public string? Description { get; set; }

	[JsonPropertyName("default")]
	public bool? Default { get; set; }

	[JsonPropertyName("paymentDescription")]
	public string? PaymentDescription { get; set; }
}
