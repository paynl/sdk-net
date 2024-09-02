using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V2.DataTransferModels.ContactMethods;

public class ContactMethod
{
	/// <summary>
	/// The type of contact method.
	/// (email email_support phone phone_helpdesk phone_off_hours url email_msnskype)
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// The value of the contact method.
	/// </summary>
	[JsonPropertyName("value")]
	public string? Value { get; set; }

	/// <summary>
	/// The description of the contact method.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Is the contact method public accessible
	/// </summary>
	[JsonPropertyName("public")]
	public bool Public { get; set; }

	/// <summary>
	///	Does the contact method needs to receive notifications
	/// </summary>
	[JsonPropertyName("notifications")]
	public bool Notifications { get; set; }
}
