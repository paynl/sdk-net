using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.PaymentInformation;

public class Payment
{
	/// <summary>
	/// Defines the method in which the card details are submitted.
	/// Choose CSE when submitting the details in cse format, card when submitting plain card data.
	/// Note: the corresponding array must be included in the request.
	/// </summary>
	[JsonPropertyName("method")]
	public string? Method { get; set; }

	[JsonPropertyName("cse")]
	public Cse? Cse { get; set; }

	[JsonPropertyName("card")]
	public Card? Card { get; set; }

	[JsonPropertyName("auth")]
	public Auth? Auth { get; set; }

}
