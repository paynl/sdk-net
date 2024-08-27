using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.PaymentInformation;

public class Cse
{
	/// <summary>
	/// The encrypted card details, base64 encoded. See the card option for the fields that should be part of the encrypted card data.
	/// </summary>
	[JsonPropertyName("identifier")]
	public string? Id { get; set; }

	/// <summary>
	/// ID of the public key that is used to encrypt the card details.
	/// </summary>
	[JsonPropertyName("data")]
	public string? Data { get; set; }
}
