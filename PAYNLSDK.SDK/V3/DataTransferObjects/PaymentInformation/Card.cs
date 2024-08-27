using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.PaymentInformation;

public class Card
{
	/// <summary>
	/// The customer's card number
	/// </summary>
	[JsonPropertyName("number")]
	public string? Number { get; set; }

	/// <summary>
	/// Expire month of the card in MM format (2 digits).
	/// </summary>
	[JsonPropertyName("expire_month")]
	public string? ExpireMonth { get; set; }

	/// <summary>
	/// Year the card expires in YY format (2 digits).
	/// </summary>
	[JsonPropertyName("expire_year")]
	public string? ExpireYear { get; set; }

	/// <summary>
	/// The name of the customer as printed on his/her card
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }
}
