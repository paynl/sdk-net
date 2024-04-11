using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.Requests.Orders;

public class V3Notification
{
	/// <summary>
	///		Use "push" for push messages, or "email" to send out an email.
	///		For more information check the following page: https://paynl.readme.io/reference/accounts-1
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; }

	/// <summary>
	///		The recipient of the notification. For push messages, use your device id (AD-XXXX-XXXX).
	///		For email, provide a valid email address (XXXX@XXXX.XX).
	/// </summary>
	[JsonPropertyName("recipient")]
	public string Recipient { get; set; }
}
